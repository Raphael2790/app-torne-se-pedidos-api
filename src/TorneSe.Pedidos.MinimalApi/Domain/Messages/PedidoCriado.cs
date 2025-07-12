using TorneSe.Pedidos.MinimalApi.Domain.Enums;

namespace TorneSe.Pedidos.MinimalApi.Domain.Messages;

public sealed class PedidoCriado : Message
{
    public string PedidoId { get; set; }
    public string DataPedido { get; set; }
    public StatusPedido Status { get; set; }
}
