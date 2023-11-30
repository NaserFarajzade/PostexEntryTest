using Services.Abstraction.Infrastructure;

namespace WebAPI.Infrastructure.Implementation;

public class ConfigurationFactory : IConfigurationFactory
{
    private readonly IConfigurationRoot _configurationRoot;

    public ConfigurationFactory(IConfigurationRoot configurationRoot)
    {
        _configurationRoot = configurationRoot;
    }
    public string GetUrl(string type)
    {
        return _configurationRoot[type + "Url"];
    }
}