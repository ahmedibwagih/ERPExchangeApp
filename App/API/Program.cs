using Application;
using Application.Core.Services;
using Core;
using Dynamo.App.Filters;
using Dynamo.Context;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

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


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
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
