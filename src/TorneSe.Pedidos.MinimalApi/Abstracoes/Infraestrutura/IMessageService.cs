using TorneSe.Pedidos.MinimalApi.Domain.Messages;

namespace TorneSe.Pedidos.MinimalApi.Abstracoes.Infraestrutura;

public interface IMessageService
{
    Task<bool> SendAsync<T>(T message, string queueUrl) where T : Message;
}