using Services.Abstraction;
using Services.Abstraction.Infrastructure;

namespace Services.Implementation;

public class UserService: IUserService
{
    private readonly IConfigurationFactory _configurationFactory;
    private readonly IApiCaller _apiCaller;
    private readonly IFileWriter _fileWriter;

    public UserService(IConfigurationFactory configurationFactory, IApiCaller apiCaller, IFileWriter fileWriter)
    {
        _configurationFactory = configurationFactory;
        _apiCaller = apiCaller;
        _fileWriter = fileWriter;
    }
    public async Task SaveAllUsersToFileAsync()
    {
        var url = _configurationFactory.GetUrl(nameof(UserService));
        var result = await _apiCaller.ExecuteAndGetResultAsync(url);
        if (result is not null)
        {
            await _fileWriter.WriteToFileAsync("Files/users.txt", result.Response, true);
        }
    }
}