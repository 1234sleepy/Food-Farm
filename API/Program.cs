using Microsoft.EntityFrameworkCore;
using Domain.DependencyInjection;
using Storage;
using Storage.DependencyInjection;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions { WebRootPath = "Images"});

builder.Services.AddDomain();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddStorage(builder.Configuration.GetConnectionString("Postgres")!);

builder.Services.AddCors();



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.Use(async (context, next) => {
    Console.WriteLine();
    await next(context);
});
app.UseStaticFiles();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<DataContext>().Database.Migrate();
}
app.Run();

public partial class Program;