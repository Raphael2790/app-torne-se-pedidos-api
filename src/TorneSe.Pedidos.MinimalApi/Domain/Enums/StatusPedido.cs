namespace TorneSe.Pedidos.MinimalApi.Domain.Enums;

public enum StatusPedido
{
    Pendente = 1,
    Reservado = 2,
    PendentePagamento = 3,
    Pago = 4,
    EmTransporte = 5,
    Entregue = 6,
    Cancelado = 7,
    Devolvido = 8,
    Finalizado = 9
}
