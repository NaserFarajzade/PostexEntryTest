using Services.Record;

namespace Services.Abstraction.Infrastructure;

public interface IApiCaller
{
    Task<ApiResponse?> ExecuteAndGetResultAsync(string apiUrl);
}