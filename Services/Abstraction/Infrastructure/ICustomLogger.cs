namespace Services.Abstraction.Infrastructure;

public interface ICustomLogger
{
    void LogInformation(string information);
    void LogException(Exception exception);
}