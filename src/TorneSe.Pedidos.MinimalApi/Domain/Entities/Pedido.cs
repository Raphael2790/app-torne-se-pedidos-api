namespace TorneSe.Pedidos.MinimalApi.Domain.Entities;

public class Pedido
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Produto { get; set; }
    public decimal Valor { get; set; }
}
