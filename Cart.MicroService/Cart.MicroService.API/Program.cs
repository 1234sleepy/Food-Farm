using Cart.MicroService.Storage.DependencyInjection;
using Cart.MicroService.Domain.DependencyInjection;
using Cart.MicroService.Storage;
using Microsoft.EntityFrameworkCore;
using Cart.MicroService.API.Extensions;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();
builder.Services.AddDomain();
builder.Services.AddSwaggerGen();

builder.Services.AddStorage(builder.Configuration.GetConnectionString("Postgres")!);

var app = builder.Build();
app.UseErrorMiddleware();
app.UseSwagger();
app.UseSwaggerUI();
app.UseMonitoringMiddleWare();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<DataContext>().Database.Migrate();
}

app.Run();
