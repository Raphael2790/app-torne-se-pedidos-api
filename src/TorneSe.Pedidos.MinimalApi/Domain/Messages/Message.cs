namespace TorneSe.Pedidos.MinimalApi.Domain.Messages;

public abstract class Message
{
    public Guid Id { get; set; }
    public DateTime Timestamp { get; set; }

    protected Message()
    {
        Id = Guid.NewGuid();
        Timestamp = DateTime.Now;
    }
}