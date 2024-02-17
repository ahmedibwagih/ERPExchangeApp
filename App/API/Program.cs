using Application;
using Application.Core.Services;
using Core;
using Dynamo.App.Filters;
using Dynamo.App.Swagger;
using Dynamo.Context;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = new AppSettings();
builder.Configuration.Bind(config);
builder.Services.AddInfrastructureDI(config);
builder.Services.AddDynamoInfrastructureDI();
builder.Services.AddApplicationDI(config);


builder.Services.AddControllers(options =>
{
    options.Filters.Add(new DynamoValidationActionFilter());
    options.Filters.Add(typeof(DynamoValidationActionFilter));
});
//    .AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
//});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


//builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();





builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

     // Jwt Bearer
     .AddJwtBearer(options =>
     {
         options.SaveToken = true;
         options.RequireHttpsMetadata = false;
         options.TokenValidationParameters = new TokenValidationParameters()
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidAudience = config.Jwt.Audience,
             ValidIssuer = config.Jwt.Issuer,
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Jwt.SecretKey))
         };
         options.Events = new JwtBearerEvents
         {
             OnMessageReceived = context =>
             {
                 var accessToken = context.Request.Query["access_token"];

                 var path = context.HttpContext.Request.Path;
                 if (!string.IsNullOrEmpty(accessToken) &&
                     (path.StartsWithSegments("/notify")))
                 {
                     context.Token = accessToken;
                 }
                 return Task.CompletedTask;
             },
             OnAuthenticationFailed = context =>
             {
                 if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                 {
                     context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
                 }
                 return Task.CompletedTask;
             }
         };
     });

builder.Services.AddSignalR();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
                      builder =>
                      {
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                          builder.AllowAnyOrigin();
                      });
});


//builder.Services.AddAutoMapper(typeof(Startup));

builder.Services.AddSwaggerGen(swagger =>
{
    //add custom header for all requests
   //swagger.OperationFilter<DynamoSwaggerOperationFilter>();
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "App.API",
        Description = "App.API"
    });

    swagger.CustomOperationIds(
            d => (d.ActionDescriptor as ControllerActionDescriptor)?.ControllerName + (d.ActionDescriptor as ControllerActionDescriptor)?.ActionName
        );

    // add swagger (JWT)  
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
});








var app = builder.Build();






if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ErpExchange V1");
    });
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<DBContext>(options =>
        {
            options.UseSqlServer(config.ConnectionStrings.Db);
        });

        // Add other services as needed
        // services.AddScoped<IYourRepository, YourRepository>();
        services.AddInfrastructureDI(config);
        services.AddDynamoInfrastructureDI();
        services.AddApplicationDI(config);
        // services.AddHostedService<IServiceScopeFactory>(); // Example of adding a hosted service
    });

//builder.Services.AddDbContext<DbContext>(options =>
//                options.UseSqlServer(config.ConnectionStrings.Db));
using var scope = ((IApplicationBuilder)app).ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
scope?.ServiceProvider.GetRequiredService<DBContext>().Database.Migrate();

app.Run();
