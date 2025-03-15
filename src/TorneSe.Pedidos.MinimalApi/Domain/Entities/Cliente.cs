namespace TorneSe.Pedidos.MinimalApi.Domain.Entities;

public sealed class Cliente
{   
    public required Guid Id { get; set; }
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public string Telefone { get; set; }
    public Endereco Endereco { get; set; }    
}
