namespace TorneSe.Pedidos.MinimalApi.Abstracoes.Infraestrutura;

public interface IDbService
{
    Task<bool> SaveAsync<T>(T entity);
}