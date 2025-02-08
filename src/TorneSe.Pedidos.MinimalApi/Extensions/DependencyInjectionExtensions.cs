using Amazon.SQS;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TorneSe.Pedidos.MinimalApi.Abstracoes.Infraestrutura;
using TorneSe.Pedidos.MinimalApi.Infraestrutura.Services;

namespace TorneSe.Pedidos.MinimalApi.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddMinimalApiServices(this IServiceCollection services)
    {
        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.AddDebug();
        });

        services.AddControllers();
        services.AddAWSLambdaHosting(LambdaEventSource.RestApi);
        services.TryAddScoped<IDbService, DbService>();
        services.TryAddScoped<IAmazonSQS, AmazonSQSClient>();
        services.TryAddScoped<IMessageService, MessageService>();

        return services;
    }
}