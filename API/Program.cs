using Microsoft.EntityFrameworkCore;
using Domain.DependencyInjection;
using Storage;
using Storage.DependencyInjection;
using API.Controllers;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions { WebRootPath = "Images"});

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
app.Use(async (context, next) => {
    Console.WriteLine();
    await next(context);
});
#endif
app.UseStaticFiles();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<DataContext>().Database.Migrate();
}
app.Run();
namespace API
{
    public partial class Program { }
}
