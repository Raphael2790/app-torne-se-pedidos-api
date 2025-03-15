namespace TorneSe.Pedidos.MinimalApi.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; set; }
    public DateTime DataCriacao { get; set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        DataCriacao = DateTime.Now;
    }
}
