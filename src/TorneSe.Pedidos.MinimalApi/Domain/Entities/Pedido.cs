using TorneSe.Pedidos.MinimalApi.Domain.Enums;

namespace TorneSe.Pedidos.MinimalApi.Domain.Entities;

public sealed class Pedido : Entity
{
    public Cliente Cliente { get; set; }
    public DateTime DataPedido { get; set; }
    public StatusPedido Status { get; set; }
    public PedidoItem[] Itens { get; set; } = [];
    public FormaPagamento[] FormasPagamento { get; set; } = [];
    public decimal ValorTotal => Itens.Sum(i => i.Total);
    public Endereco EnderecoEntrega { get; set; }
}
