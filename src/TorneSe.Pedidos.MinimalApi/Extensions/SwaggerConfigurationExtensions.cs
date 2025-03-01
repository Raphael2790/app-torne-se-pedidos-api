using Microsoft.OpenApi.Models;

namespace TorneSe.Pedidos.MinimalApi.Extensions;

public static class SwaggerConfigurationExtensions
{
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => 
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Minha API com AWS Lambda",
                Version = "v1",
                Description = "API de pedidos integrada com AWS Lambda"
            });

            // options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            // {
            //     In = ParameterLocation.Header,
            //     Description = "Insira o token JWT no formato: Bearer {seu_token}",
            //     Name = "Authorization",
            //     Type = SecuritySchemeType.Http,
            //     Scheme = "Bearer"
            // });

            // options.AddSecurityRequirement(new OpenApiSecurityRequirement
            // {
            //     {
            //         new OpenApiSecurityScheme
            //         {
            //             Reference = new OpenApiReference
            //             {
            //                 Type = ReferenceType.SecurityScheme,
            //                 Id = "Bearer"
            //             }
            //         },
            //         new string[] {}
            //     }
            // });

        });

        return services;
    }

    public static WebApplication UseSwaggerInterface(this WebApplication app, IConfiguration configuration)
    {
        app.UseSwagger();

        var swaggerUrl = configuration.GetValue<string>("Swagger:Url");

        app.UseSwaggerUI(options => 
        {
            options.SwaggerEndpoint(swaggerUrl, "Minha API com AWS Lambda");
        });

        return app;
    }
}