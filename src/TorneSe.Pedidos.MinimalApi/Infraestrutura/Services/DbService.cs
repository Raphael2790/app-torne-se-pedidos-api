using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using TorneSe.Pedidos.MinimalApi.Abstracoes.Infraestrutura;

namespace TorneSe.Pedidos.MinimalApi.Infraestrutura.Services;

public class DbService(ILogger<DbService> logger, IAmazonDynamoDB dynamoDb) : IDbService
{
    private readonly DynamoDBContext _dbContext = new(dynamoDb);

    public async Task<bool> SaveAsync<T>(T entity)
    {
        try
        {
            await _dbContext.SaveAsync(entity);
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao salvar entidade no DynamoDB");
            return false;
        }
    }
}