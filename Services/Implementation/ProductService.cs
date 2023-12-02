using Services.Abstraction;
using Services.Abstraction.Infrastructure;

namespace Services.Implementation;

public class ProductService: IProductService
{
    private readonly IConfigurationFactory _configurationFactory;
    private readonly IApiCaller _apiCaller;
    private readonly IFileWriter _fileWriter;

    public ProductService(IConfigurationFactory configurationFactory, IApiCaller apiCaller, IFileWriter fileWriter)
    {
        _configurationFactory = configurationFactory;
        _apiCaller = apiCaller;
        _fileWriter = fileWriter;
    }
    public async Task SaveAllProductsToFileAsync()
    {
        var url = _configurationFactory.GetUrl(nameof(ProductService));
        var result = await _apiCaller.ExecuteAndGetResultAsync(url);
        if (result is not null)
        {
            await _fileWriter.WriteToFileAsync("Files/products.txt", result.Response, true);
        }
    }
}