using Microsoft.EntityFrameworkCore;
using Domain.DependencyInjection;
using Storage;
using Storage.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomain();
builder.Services.AddControllers();
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
