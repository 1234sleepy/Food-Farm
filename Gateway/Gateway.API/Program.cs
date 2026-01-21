using Gateway.API.MiddleWare;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseMiddleware<EnrichHeaderMiddleWare>();

app.MapReverseProxy();

app.MapControllers();

app.Run();
