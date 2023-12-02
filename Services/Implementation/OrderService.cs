using Services.Abstraction;
using Services.Abstraction.Infrastructure;

namespace Services.Implementation;

public class OrderService: IOrderService
{
    private readonly IConfigurationFactory _configurationFactory;
    private readonly IApiCaller _apiCaller;
    private readonly IFileWriter _fileWriter;
    
    public OrderService(IConfigurationFactory configurationFactory, IApiCaller apiCaller, IFileWriter fileWriter)
    {
        _configurationFactory = configurationFactory;
        _apiCaller = apiCaller;
        _fileWriter = fileWriter;
    }

    public async Task SaveAllOrdersToFileAsync()
    {
        var url = _configurationFactory.GetUrl(nameof(OrderService));
        var result = await _apiCaller.ExecuteAndGetResultAsync(url);
        if (result is not null)
        {
            await _fileWriter.WriteToFileAsync("Files/orders.txt", result.Response, true);
        }
    }
}