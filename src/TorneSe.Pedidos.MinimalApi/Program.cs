using TorneSe.Pedidos.MinimalApi.Configuration;
using TorneSe.Pedidos.MinimalApi.Controllers;
using TorneSe.Pedidos.MinimalApi.Domain.Constants;
using TorneSe.Pedidos.MinimalApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMinimalApiServices();

// Register SQS options
builder.Services.Configure<MessageServiceOptions>(
    builder.Configuration.GetSection(AppConstants.MessageServiceSectionName));

// Register exception handler middleware
builder.Services.AddGlobalExceptionHandler();

builder.Services.ConfigureSwagger();

var app = builder.Build();

// Add global exception handler middleware
app.UseGlobalExceptionHandler();

app.ConfigureApp();

app.UseSwaggerInterface(builder.Configuration);

app.MapEndpoints(builder.Configuration);

app.Run();
