using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TorneSe.Pedidos.MinimalApi.Middlewares;

namespace TorneSe.Pedidos.MinimalApi.Extensions;

public static class ExceptionHandlerExtensions
{
    /// <summary>
    /// Registra o middleware de tratamento de exceções na coleção de serviços
    /// </summary>
    public static IServiceCollection AddGlobalExceptionHandler(this IServiceCollection services)
    {
        services.AddTransient<ExceptionHandlerMiddleware>();
        return services;
    }

    /// <summary>
    /// Configura o middleware de tratamento de exceções na pipeline da aplicação
    /// </summary>
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        return app;
    }
}
