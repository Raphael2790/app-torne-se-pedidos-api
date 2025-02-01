using TorneSe.Pedidos.MinimalApi.Controllers;
using TorneSe.Pedidos.MinimalApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMinimalApiServices();

var app = builder.Build();

app.ConfigureApp();

app.MapEndpoints();

app.Run();
