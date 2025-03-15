using MediatR;
using TorneSe.Pedidos.MinimalApi.Common;
using TorneSe.Pedidos.MinimalApi.UseCases.CriarPedido.Response;

namespace TorneSe.Pedidos.MinimalApi.UseCases.CriarPedido.Request;

public class CriarPedidoRequest : IRequest<Result<CriarPedidoResponse>>
{
    public Guid IdCliente { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }
    public List<PedidoItemRequest> Itens { get; set; }
}

public class PedidoItemRequest
{
    public string NomeProduto { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }
    public int IdProduto { get; set; }
}
