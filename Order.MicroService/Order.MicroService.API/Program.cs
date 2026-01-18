using Microsoft.EntityFrameworkCore;
using Order.MicroService.API.Extensions;
using Order.MicroService.Domain.DpendencyInjection;
using Order.MicroService.Storage;
using Order.MicroService.Storage.DependencyInjection;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllers();
builder.Services.AddDomain();
builder.Services.AddSwaggerGen();

builder.Services.AddStorage(builder.Configuration.GetConnectionString("Postgres")!);


var app = builder.Build();


app.UseErrorMiddleware();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<DataContext>().Database.Migrate();
}

app.Run();
