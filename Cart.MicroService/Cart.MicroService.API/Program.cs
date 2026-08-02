using Cart.MicroService.API.Extensions;
using Cart.MicroService.Domain.DependencyInjection;
using Cart.MicroService.Storage;
using Cart.MicroService.Storage.DependencyInjection;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Wolverine;

var builder = WebApplication.CreateBuilder();

builder.Host.UseWolverine(opts =>
{
    opts.Discovery.IncludeAssembly(
    System.Reflection.Assembly.Load("Cart.MicroService.Domain"));
});

//builder.Services.AddControllers();
builder.Services.AddDomain();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.FullName);
});

builder.Services.AddStorage(builder.Configuration.GetConnectionString("Postgres")!);

var app = builder.Build();
app.UseErrorMiddleware();
app.UseFastEndpoints();
app.UseSwagger();
app.UseSwaggerUI();
app.UseMonitoringMiddleWare();
//app.MapControllers();



using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<DataContext>().Database.Migrate();
}

app.Run();
