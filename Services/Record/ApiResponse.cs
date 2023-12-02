using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Services.Record;

public record ApiResponse(string ApiName, string? Response, string? Error)
{
    public override string ToString()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }
}
