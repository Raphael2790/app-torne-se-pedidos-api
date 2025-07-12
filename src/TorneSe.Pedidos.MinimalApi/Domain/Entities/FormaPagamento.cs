namespace TorneSe.Pedidos.MinimalApi.Domain.Entities;

public sealed class FormaPagamento
{
    public string Tipo { get; set; }
    public decimal Valor { get; set; }
    public int Parcelas { get; set; }
    public string TokenCartao { get; set; }
    public string Bandeira { get; set; }
    public string ChavePix { get; set; }
    public string TipoChavePix { get; set; }
    public string ComprovantePix { get; set; }
}