using Services.Abstraction.Infrastructure;

namespace Services.Implementation.Infrastructure
{
    public class FileWriter : IFileWriter 
    {
        public async Task WriteToFileAsync(string filePath, string content, bool append)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            var directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            
            var fileMode = append ? FileMode.Append : FileMode.Create;

            await using var fileStream = new FileStream(filePath, fileMode, FileAccess.Write, FileShare.Read);
            await using var writer = new StreamWriter(fileStream);
            await writer.WriteAsync(content + "\n");
        }
    }
}