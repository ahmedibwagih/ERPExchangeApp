using System.Linq;
using System.Threading.Tasks;
using Dynamo.App.Filters;
using Dynamo.Context.Identity;
using Dynamo.Core.Other;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public class AppAuthorize:DynamoAuthorize
    {
        protected AuthorizationFilterContext Context;
        public override Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            Context = context;
            
            return base.OnAuthorizationAsync(context);
        }

        protected override void OnReadAuthorizations(string userId, string userName)
        {
            var session = Context.HttpContext.RequestServices.GetService<DynamoSession>();
            session.UserId = userId;
            session.UserName = userName;
         
        }

        protected override async Task<bool> OnCheckPermissions(string[] permissions)
        {
            var session = Context.HttpContext.RequestServices.GetService<DynamoSession>();
            var userManager = Context.HttpContext.RequestServices.GetService<DynamoUserManager>();
            var grantedPermissions = await userManager.GetUserPermission(session.UserId);
            return grantedPermissions.Any(x => permissions.Contains(x));
        }


    }
}
