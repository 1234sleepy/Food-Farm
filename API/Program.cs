using API.Controllers;
using Domain.DependencyInjection;
using Domain.UseCases.AccountOperations.Command.CreateAccount;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Storage;
using Storage.DependencyInjection;
using Storage.Entities;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions { WebRootPath = "Images" });

builder.Services.AddControllers().AddApplicationPart(typeof(AdminController).Assembly);
builder.Services.AddDomain();
builder.Services.AddSwaggerGen();
builder.Services.AddStorage(builder.Configuration.GetConnectionString("Postgres")!);
#if DEBUG
builder.Services.AddCors();
#endif



var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
#if DEBUG
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
#endif
app.UseStaticFiles();

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
