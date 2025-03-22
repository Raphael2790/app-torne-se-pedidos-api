using AutoMapper;
using MediatR;
using TorneSe.Pedidos.MinimalApi.Abstracoes.Infraestrutura;
using TorneSe.Pedidos.MinimalApi.Common;
using TorneSe.Pedidos.MinimalApi.Domain.Entities;
using TorneSe.Pedidos.MinimalApi.Domain.Messages;
using TorneSe.Pedidos.MinimalApi.Infraestrutura.Models;
using TorneSe.Pedidos.MinimalApi.UseCases.CriarPedido.Request;
using TorneSe.Pedidos.MinimalApi.UseCases.CriarPedido.Response;

namespace TorneSe.Pedidos.MinimalApi.UseCases.CriarPedido;

public sealed class Handler(ILogger<Handler> logger, IMapper mapper, IDbService dbService, IMediator mediator) 
    : IRequestHandler<CriarPedidoRequest, Result<CriarPedidoResponse>>
{
    public async Task<Result<CriarPedidoResponse>> Handle(CriarPedidoRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();

        var pedido = mapper.Map<Pedido>(request);

        //Validação de regras de negócio do pedido
        if (pedido.Itens.Length == 0)
            return Result<CriarPedidoResponse>.Error("Pedido sem itens");

        var pedidoModel = mapper.Map<PedidoDynamoModel>(pedido);

        //Criar um tabela local no localstack para simular o DynamoDB
        var pedidoSalvo = await dbService.SaveAsync(pedidoModel);

        if (!pedidoSalvo)
            return Result<CriarPedidoResponse>.Error("Erro ao salvar pedido");

        var pedidoCriado = mapper.Map<PedidoCriado>(pedido);

        //Criar o handler de envio para a fila de estoque
        //Criar uma fila local no localstack para simular o SQS
        await mediator.Publish(pedidoCriado, cancellationToken);

        var response = mapper.Map<CriarPedidoResponse>(pedidoCriado);

        return Result<CriarPedidoResponse>.Success(response);
    }
}