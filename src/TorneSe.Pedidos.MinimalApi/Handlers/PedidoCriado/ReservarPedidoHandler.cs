using MediatR;
using Microsoft.Extensions.Options;
using TorneSe.Pedidos.MinimalApi.Abstracoes.Infraestrutura;
using TorneSe.Pedidos.MinimalApi.Configuration;
using TorneSe.Pedidos.MinimalApi.Domain.Messages;

namespace TorneSe.Pedidos.MinimalApi.Handlers;

public class ReservarPedidoHandler(
    IMessageService messageService,
    ILogger<ReservarPedidoHandler> logger,
    IOptions<MessageServiceOptions> messageOptions) : INotificationHandler<PedidoCriado>
{
    public async Task Handle(PedidoCriado notification, CancellationToken cancellationToken)
    {
       logger.LogInformation("Pedido criado: {Pedido}", notification);

        var result = await messageService.SendAsync(notification, messageOptions.Value.PedidosCriadosQueueUrl);

        if (!result)
            logger.LogError("Erro ao enviar mensagem para a fila");
    }
}