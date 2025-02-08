using Amazon.SQS.Model;

namespace TorneSe.Pedidos.MinimalApi.Abstracoes.Infraestrutura;

public interface IMessageService
{
    Task<bool> SendAsync<T>(T message, string queueUrl) where T : Message;
}