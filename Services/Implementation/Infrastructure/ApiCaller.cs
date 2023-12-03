using System.Diagnostics;
using RestSharp;
using Services.Abstraction.Infrastructure;
using Services.Record;

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
    
    public async Task<ApiResponse?> ExecuteAndGetResultAsync(string apiUrl)
    {
        var stopWatch = Stopwatch.StartNew();
        try
        {
            var request = new RestRequest(apiUrl, Method.Get);
            var response = await _restClient.ExecuteAsync(request);
            var duration = stopWatch.ElapsedMilliseconds;
            _logger.LogInformation($@"Api {apiUrl} Calling duration: {duration} Milli Seconds with successful result");
            if (response.IsSuccessful)
            {
                return new ApiResponse(apiUrl, response.Content, null);
            }
        }
        catch (Exception ex)
        {
            var duration = stopWatch.ElapsedMilliseconds;
            _logger.LogInformation($@"Api Calling duration: {duration} Milli Seconds with Exception result");
            _logger.LogException(ex);
            return new ApiResponse(apiUrl, null, ex.Message);
        }
        finally
        {
            stopWatch.Stop();
        }

        return null;
    }
}