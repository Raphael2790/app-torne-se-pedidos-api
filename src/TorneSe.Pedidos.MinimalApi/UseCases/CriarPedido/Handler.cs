using MediatR;
using TorneSe.Pedidos.MinimalApi.Common;
using TorneSe.Pedidos.MinimalApi.UseCases.CriarPedido.Request;
using TorneSe.Pedidos.MinimalApi.UseCases.CriarPedido.Response;

namespace TorneSe.Pedidos.MinimalApi.UseCases.CriarPedido;

public sealed class Handler(ILogger<Handler> logger) 
    : IRequestHandler<CriarPedidoRequest, Result<CriarPedidoResponse>>
{
    public Task<Result<CriarPedidoResponse>> Handle(CriarPedidoRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Criando pedido para {Nome} ({Email})", request.Nome, request.Email);

        var response = new CriarPedidoResponse
        {
            Id = Guid.NewGuid(),
            DataPedido = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
            Status = "Aguardando pagamento"
        };

        return Task.FromResult(Result<CriarPedidoResponse>.Success(response));
    }
}