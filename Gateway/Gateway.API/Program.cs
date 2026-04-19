using Gateway.API.Extensions;
using Gateway.API.MiddleWare;
using Gateway.Domain.DependecyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddDomain(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Auth:TokenKey"]!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

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
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();

app.UseErrorMiddleware();

app.UseRouting();

app.UseMiddleware<EnrichHeaderMiddleWare>();

app.Use(async (context, next) =>
{
    context.Request.Cookies.TryGetValue("access_token", out var token);
    context.Request.Headers.Append("Authorization", token != null ? $"Bearer {token}" : string.Empty);
    await next();
});


app.UseAuthentication();
app.UseAuthorization();

app.MapReverseProxy();

app.MapControllers();



app.Run();
