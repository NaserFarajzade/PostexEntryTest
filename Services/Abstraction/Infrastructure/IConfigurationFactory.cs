namespace Services.Abstraction.Infrastructure;

public interface IConfigurationFactory
{
    string GetUrl(string type);
}