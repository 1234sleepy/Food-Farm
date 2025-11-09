using Product.MicroService.Domain.DependencyInjection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Product.MicroService.Storage;
using Product.MicroService.Storage.DependencyInjection;
using Product.MicroService.Storage.Entities;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions { WebRootPath = "Images" });

builder.Services.AddControllers().AddApplicationPart(typeof().Assembly);
builder.Services.AddDomain();
builder.Services.AddStorage(builder.Configuration.GetConnectionString("Postgres")!);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
