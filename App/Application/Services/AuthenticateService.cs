using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Core.DTOs.Authentication;
using Application.Core.Services;
using Core;
using Core.DTOs;
using Core.Other;
using Core.UnitOfWork;
using Dynamo.Context.Identity;
using Dynamo.Core.Entities.Base;
using Dynamo.Core.Other;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using static Google.Apis.Requests.BatchRequest;

namespace Application.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly DynamoUserManager userManager;
        private readonly DynamoSession dynamoSession;
        private readonly AppSettings settings;
        private readonly IWebHostEnvironment env;
        private readonly IUnitOfWork unitOfWork;



        public AuthenticateService(
            DynamoUserManager userManager,
            DynamoSession dynamoSession,
            AppSettings settings,
           IWebHostEnvironment env,
          //  IUserService userService,
            IUnitOfWork unitOfWork
            )
            {
                this.userManager = userManager;
                this.dynamoSession = dynamoSession;
                this.settings = settings;
               // this.env = env;
               // this.userService = userService;
                this.unitOfWork = unitOfWork;
            }

        public async Task<object> Login(LoginDto model)
        {

            var user = await userManager.Users
                .FirstOrDefaultAsync(x => x.Email.Trim().ToLower() == model.UserName.Trim().ToLower() || x.PhoneNumber.Trim().ToLower() == model.UserName.Trim().ToLower());

            if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
                throw new DynamoException("User name or password are incorrect!");

            return await GetToken(user);

        }

     

        private async Task<object> GetToken(DynamoUser user)
        {
            dynamoSession.UserId = user.Id;
            dynamoSession.UserName = user.UserName;

            var userRoles = await userManager.GetRolesAsync(user);



            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("userId", user.Id),
                new Claim("typeId", user.TypeId.HasValue?user.TypeId.ToString():""),
                new Claim("type", user.Type.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey));

            var expires = DateTime.Now.ToUniversalTime().AddHours(5);

            //if (env.IsDevelopment())
            //{
                expires = DateTime.Now.ToUniversalTime().AddMonths(1);
           // }

            var token = new JwtSecurityToken(
                issuer: settings.Jwt.Issuer,
                audience: settings.Jwt.Audience,
                expires: expires,
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new TokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }

    



    
   
    }

    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
