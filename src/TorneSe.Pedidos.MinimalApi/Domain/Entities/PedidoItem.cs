namespace TorneSe.Pedidos.MinimalApi.Domain.Entities;

public sealed class PedidoItem
{
    public string NomeProduto { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
    public decimal Total => Valor * Quantidade;
    public int IdProduto { get; set; }
}