using TorneSe.Pedidos.MinimalApi.Domain.Entities;

namespace TorneSe.Pedidos.MinimalApi.Controllers;

public static class PedidosApiController
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

        var pedidosGroup = app.MapGroup("api/pedidos")
            .WithTags("Pedidos");

        pedidosGroup.MapGet("/", () => new[] { "Pedido 1", "Pedido 2", "Pedido 3" });

        pedidosGroup.MapGet("/{id}", (int id) => $"Pedido {id}");

        pedidosGroup.MapPost("/", (Pedido pedido) =>
        {
            pedido.Id = 4;
            return pedido;
        });

        pedidosGroup.MapDelete("/{id}", (int id) => $"Pedido {id} deletado");
    }
}