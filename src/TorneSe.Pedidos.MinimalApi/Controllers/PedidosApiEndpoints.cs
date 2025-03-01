using TorneSe.Pedidos.MinimalApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using TorneSe.Pedidos.MinimalApi.Common;
using TorneSe.Pedidos.MinimalApi.UseCases.CriarPedido.Response;
using TorneSe.Pedidos.MinimalApi.UseCases.CriarPedido.Request;
using MediatR;

namespace TorneSe.Pedidos.MinimalApi.Controllers;

public static class PedidosApiController
{
    public static void MapEndpoints(this IEndpointRouteBuilder app, IConfiguration configuration)
    {
        var swaggerUrl = configuration.GetValue<string>("Swagger:Url");

        app.MapGet("/", () => Results.Redirect(swaggerUrl!)).ExcludeFromDescription();

        var pedidosGroup = app.MapGroup("api/pedidos")
            .WithTags("Pedidos");

        pedidosGroup.MapGet("/", () => new[] { "Pedido 1", "Pedido 2", "Pedido 3" });

        pedidosGroup.MapGet("/{id}", (int id) => $"Pedido {id}");

        pedidosGroup.MapPost("/", async Task<Results<Ok<Result<CriarPedidoResponse>>, BadRequest<Result<CriarPedidoResponse>>>> ([FromServices] IMediator mediator,[FromBody] CriarPedidoRequest request) =>
        {
            var result = await mediator.Send(request);

            if (result.IsSuccess)
            {
                return TypedResults.Ok(result);
            }

            return TypedResults.BadRequest(result);
        });

        pedidosGroup.MapDelete("/{id}", (int id) => $"Pedido {id} deletado");
    }
}