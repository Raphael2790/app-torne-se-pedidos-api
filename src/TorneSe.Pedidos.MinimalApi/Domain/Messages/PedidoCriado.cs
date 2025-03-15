using TorneSe.Pedidos.MinimalApi.Domain.Enums;

namespace TorneSe.Pedidos.MinimalApi.Domain.Messages;

public sealed class PedidoCriado : Message
{
    public DateTime DataPedido { get; set; }
    public string PedidoCompleto { get; set; }
    public decimal ValorTotal { get; set; }
    public StatusPedido StatusPedido { get; set; }
}
