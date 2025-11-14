using Microsoft.EntityFrameworkCore;
using Product.MicroService.API.Controllers;
using Product.MicroService.Domain.DependencyInjection;
using Product.MicroService.Storage.DependencyInjection;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions { WebRootPath = "Images" });

builder.Services.AddControllers().AddApplicationPart(typeof(ProductController).Assembly);
builder.Services.AddDomain();

builder.Services.AddStorage(builder.Configuration.GetConnectionString("Postgres")!);


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();


app.Run();
