using TorneSe.Pedidos.MinimalApi.Domain.Enums;

namespace TorneSe.Pedidos.MinimalApi.UseCases.CriarPedido.Response;

public class CriarPedidoResponse
{
    public Guid Id { get; set; }
    public DateTime DataPedido { get; set; }
    public StatusPedido StatusPedido { get; set; }
}