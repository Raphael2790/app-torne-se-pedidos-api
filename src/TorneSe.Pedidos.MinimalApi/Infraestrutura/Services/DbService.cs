using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using TorneSe.Pedidos.MinimalApi.Abstracoes.Infraestrutura;

namespace TorneSe.Pedidos.MinimalApi.Infraestrutura.Services;

public class DbService : IDbService
{
    private readonly ILogger<DbService> _logger;
    private readonly IAmazonDynamoDB _dynamoDb;
    private readonly DynamoDBContext _dbContext;

    public DbService(ILogger<DbService> logger, IAmazonDynamoDB dynamoDb)
    {
        _logger = logger;
        _dynamoDb = dynamoDb;
        _dbContext = new DynamoDBContext(dynamoDb);
    }

    public async Task<bool> SaveAsync<T>(T entity)
    {
        try
        {
            await _dbContext.SaveAsync(entity);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao salvar entidade no DynamoDB");
            return false;
        }
    }
}
