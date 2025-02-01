using TorneSe.Pedidos.MinimalApi.Extensions;

public static class ConfigureAppExtensions
{
    public static WebApplication ConfigureApp(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }
}