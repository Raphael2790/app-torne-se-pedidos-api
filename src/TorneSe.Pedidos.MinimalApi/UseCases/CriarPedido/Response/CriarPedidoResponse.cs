namespace TorneSe.Pedidos.MinimalApi.UseCases.CriarPedido.Response;

public class CriarPedidoResponse
{
    public Guid Id { get; set; }
    public string DataPedido { get; set; }
    public string Status { get; set; }
}