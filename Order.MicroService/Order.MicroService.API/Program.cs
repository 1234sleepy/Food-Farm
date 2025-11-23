using Order.MicroService.API.Controllers;
using Order.MicroService.Domain.DpendencyInjection;
using Order.MicroService.Storage.DependencyInjection;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions { WebRootPath = "Images" });

builder.Services.AddControllers().AddApplicationPart(typeof(OrderController).Assembly);
builder.Services.AddDomain();
builder.Services.AddSwaggerGen();

builder.Services.AddStorage(builder.Configuration.GetConnectionString("Postgres")!);


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();


app.Run();
