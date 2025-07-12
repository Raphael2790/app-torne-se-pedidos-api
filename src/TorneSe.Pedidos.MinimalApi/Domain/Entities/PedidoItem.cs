namespace TorneSe.Pedidos.MinimalApi.Domain.Entities;

public sealed class PedidoItem : Entity
{
    public string NomeProduto { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
    public decimal Total => Valor * Quantidade;
    public int IdSku { get; set; }
}