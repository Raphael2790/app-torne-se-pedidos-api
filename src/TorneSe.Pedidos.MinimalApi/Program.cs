using TorneSe.Pedidos.MinimalApi.Controllers;
using TorneSe.Pedidos.MinimalApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMinimalApiServices();

builder.Services.ConfigureSwagger();

var app = builder.Build();

app.ConfigureApp();

app.UseSwaggerInterface(builder.Configuration);

app.MapEndpoints(builder.Configuration);

app.Run();
