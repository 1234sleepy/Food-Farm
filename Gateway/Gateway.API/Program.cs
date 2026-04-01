using Gateway.API.Extensions;
using Gateway.API.MiddleWare;
using Gateway.Domain.DependecyInjection;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();


builder.Services.AddDomain(builder.Configuration);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    policy =>
    {
        policy.WithOrigins("http://localhost:4200")
               .AllowCredentials()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseErrorMiddleware();

app.UseRouting();
app.UseCors();




app.UseMiddleware<EnrichHeaderMiddleWare>();

app.MapReverseProxy();

app.MapControllers();

app.Run();
