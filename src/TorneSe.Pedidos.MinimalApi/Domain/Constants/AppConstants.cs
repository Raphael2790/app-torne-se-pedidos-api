using System.Text.Json;
using System.Text.Json.Serialization;

namespace TorneSe.Pedidos.MinimalApi.Domain.Constants;

public static class AppConstants
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        WriteIndented = false,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    public static JsonSerializerOptions JsonSerializerOptions => _jsonSerializerOptions;
}
