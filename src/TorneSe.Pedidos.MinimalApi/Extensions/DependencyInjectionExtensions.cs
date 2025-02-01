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

        return services;
    }
}