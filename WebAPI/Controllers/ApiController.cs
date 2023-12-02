using System.Net;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction.Infrastructure;
using Services.Implementation;
using Services.Record;

namespace WebAPI.Controllers;

public class ApiController : Controller
{
    private readonly IApiCaller _apiCaller;
    private readonly ILogger<ApiController> _logger;
    private readonly IConfigurationFactory _configurationFactory;
    private readonly IFileWriter _fileWriter;

    public ApiController(IApiCaller apiCaller, 
        ILogger<ApiController> logger, 
        IConfigurationFactory configurationFactory,
        IFileWriter fileWriter)
    {
        _apiCaller = apiCaller;
        _logger = logger;
        _configurationFactory = configurationFactory;
        _fileWriter = fileWriter;
    }
    
    [HttpGet("call-apis")]
    public async Task<IActionResult> CallApis()
    {
        var url1 = _configurationFactory.GetUrl(nameof(OrderService));
        var url2 = _configurationFactory.GetUrl(nameof(ProductService));
        var url3 = _configurationFactory.GetUrl(nameof(UserService));

        try
        {
            var tasks = new List<Task<ApiResponse>?>
            {
                _apiCaller.ExecuteAndGetResultAsync(url1),
                _apiCaller.ExecuteAndGetResultAsync(url2),
                _apiCaller.ExecuteAndGetResultAsync(url3)
            };

            var results = await Task.WhenAll(tasks);

            await _fileWriter.WriteToFileAsync("Files/AllApis.txt", results, true);
            return Ok(results);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while calling APIs");
            return StatusCode((int)HttpStatusCode.InternalServerError, "Internal Server Error");
        }
    }
}