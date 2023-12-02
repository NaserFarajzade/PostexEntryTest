namespace Services.Abstraction.Infrastructure;

public interface IFileWriter
{
    Task WriteToFileAsync(string filePath, string content, bool append);
    Task WriteToFileAsync(string filePath, object content, bool append);
}