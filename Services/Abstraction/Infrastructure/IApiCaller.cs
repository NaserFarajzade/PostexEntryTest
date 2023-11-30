using RestSharp;

namespace Services.Abstraction.Infrastructure;

public interface IApiCaller
{
    Task<string?> ExecuteAndGetResponseAsync(string apiUrl);
}