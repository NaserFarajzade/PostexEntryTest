using Services.Abstraction.Infrastructure;

namespace WebAPI.Infrastructure.Implementation;

public class CustomLogger : ICustomLogger
{
    private readonly ILogger<CustomLogger> _logger;

    public CustomLogger(ILogger<CustomLogger> logger)
    {
        _logger = logger;
    }

    public void LogInformation(string information)
    {
        _logger.LogInformation(information);
    }

    public void LogException(Exception exception)
    {
        _logger.LogError(exception.Message);
    }
}