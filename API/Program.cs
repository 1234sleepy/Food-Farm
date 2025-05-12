using API.Controllers;
using Domain.DependencyInjection;
using Domain.UseCases.AccountOperations.Command.CreateAccount;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Storage;
using Storage.DependencyInjection;
using Storage.Entities;
using System.Text;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions { WebRootPath = "Images" });

builder.Services.AddControllers().AddApplicationPart(typeof(AdminController).Assembly);
builder.Services.AddDomain();
builder.Services.AddSwaggerGen();
builder.Services.AddStorage(builder.Configuration.GetConnectionString("Postgres")!);
#if DEBUG
builder.Services.AddCors();
#endif
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

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options
        .WithOrigins("http://localhost:4200")
        .AllowCredentials()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

builder.Services.AddAuthorization();


var app = builder.Build();

app.UseCors("AllowOrigin");
app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.Use(async (context, next) =>
{
    context.Request.Cookies.TryGetValue("access_token", out var token);
    context.Request.Headers.Append("Authorization", token != null ? $"Bearer {token}" : string.Empty);
    await next();
});


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<DataContext>().Database.Migrate();
    var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();

    if (!await scope.ServiceProvider.GetRequiredService<DataContext>().Users.AnyAsync(x => x.UserName == config["AdminCredentials:UserName"]))
    {
        var createAccountCommand = new CreateAccountCommand(
            config["AdminCredentials:UserName"]!,
            config["AdminCredentials:Password"]!,
            config["AdminCredentials:Email"]!,
            Roles.Admin
        );

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        await mediator.Send(createAccountCommand);
    }

}


app.Run();
namespace API
{
    public partial class Program { }
}
