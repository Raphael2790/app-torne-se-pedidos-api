using TorneSe.Pedidos.MinimalApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TorneSe.Pedidos.MinimalApi.Controllers;

public static class PedidosApiController
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

        var pedidosGroup = app.MapGroup("api/pedidos")
            .WithTags("Pedidos");

        pedidosGroup.MapGet("/", GetAllPedidos);

        pedidosGroup.MapGet("/{id}", GetPedidoById);

        pedidosGroup.MapPost("/", CreatePedido);

        pedidosGroup.MapDelete("/{id}", DeletePedido);
    }

    private static IResult GetAllPedidos()
    {
        var pedidos = new[] { "Pedido 1", "Pedido 2", "Pedido 3" };
        return Results.Ok(pedidos);
    }

    private static IResult GetPedidoById(int id)
    {
        if (id <= 0)
        {
            return Results.BadRequest("Invalid ID");
        }
        return Results.Ok($"Pedido {id}");
    }

    private static IResult CreatePedido([FromBody] Pedido pedido)
    {
        if (pedido == null)
        {
            return Results.BadRequest("Pedido is required");
        }
        pedido.Id = 4;
        return Results.Created($"/api/pedidos/{pedido.Id}", pedido);
    }

    private static IResult DeletePedido(int id)
    {
        if (id <= 0)
        {
            return Results.BadRequest("Invalid ID");
        }
        return Results.Ok($"Pedido {id} deletado");
    }
}