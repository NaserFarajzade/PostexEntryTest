namespace Services.Abstraction.Infrastructure;

public interface IFileWriter
{
    Task WriteToFileAsync(string filePath, string content, bool append);
}