using System.Net;
using System.Text.Json;
using Amazon.SQS;
using TorneSe.Pedidos.MinimalApi.Abstracoes.Infraestrutura;
using TorneSe.Pedidos.MinimalApi.Domain.Messages;

namespace TorneSe.Pedidos.MinimalApi.Infraestrutura.Services;

public sealed class MessageService(ILogger<MessageService> logger, IAmazonSQS sqsClient) : IMessageService
{
    public async Task<bool> SendAsync<T>(T message, string queueUrl) where T : Message
    {
        try
        {
            var request = new Amazon.SQS.Model.SendMessageRequest
            {
                QueueUrl = queueUrl,
                MessageBody = JsonSerializer.Serialize(message)
            };
    
            var response = await sqsClient.SendMessageAsync(request);
    
            return response.HttpStatusCode is HttpStatusCode.OK;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao enviar mensagem para a fila SQS");
            return false;
        }
    }
}