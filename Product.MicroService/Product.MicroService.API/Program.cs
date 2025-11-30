using Microsoft.EntityFrameworkCore;
using Product.MicroService.API.Controllers;
using Product.MicroService.Domain.DependencyInjection;
using Product.MicroService.Storage;
using Product.MicroService.Storage.DependencyInjection;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions { WebRootPath = "Images" });

builder.Services.AddControllers();
builder.Services.AddDomain();
builder.Services.AddSwaggerGen();

builder.Services.AddStorage(builder.Configuration.GetConnectionString("Postgres")!);

var app = builder.Build();




app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<DataContext>().Database.Migrate();
}

app.Run();
