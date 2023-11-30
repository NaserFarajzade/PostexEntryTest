using System.Diagnostics;
using RestSharp;
using Services.Abstraction.Infrastructure;

namespace Services.Implementation.Infrastructure;

public class ApiCaller: IApiCaller
{
    private readonly IRestClient _restClient;
    private readonly ICustomLogger _logger;

    public ApiCaller(IRestClient restClient, ICustomLogger logger)
    {
        _restClient = restClient;
        _logger = logger;
    }
    
    public async Task<string?> ExecuteAndGetResponseAsync(string apiUrl)
    {
        var stopWatch = Stopwatch.StartNew();
        try
        {
            var request = new RestRequest(apiUrl, Method.Get);
            var response = await _restClient.ExecuteAsync(request);
            var duration = stopWatch.ElapsedMilliseconds;
            _logger.LogInformation($@"Api Calling duration: {duration} Milli Seconds with successful result");
            if (response.IsSuccessful)
            {
                return response.IsSuccessful ? response.Content : null;
            }
        }
        catch (Exception ex)
        {
            var duration = stopWatch.ElapsedMilliseconds;
            _logger.LogInformation($@"Api Calling duration: {duration} Milli Seconds with Exception result");
            _logger.LogException(ex);
        }
        finally
        {
            stopWatch.Stop();
        }

        return null;
    }
}