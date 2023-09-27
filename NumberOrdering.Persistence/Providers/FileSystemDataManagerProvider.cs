using NumberOrdering.Persistence.Contracts;

namespace NumberOrdering.Persistence.Providers
{
    public class FileSystemDataManagerProvider : IDataManagerProvider
    {
        public async Task WriteAsync(string text, string filePath)
        {
            using (var outputFile = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath)))
            {
                await outputFile.WriteAsync(text);
            } 
        }

        public async Task<string> ReadAsync(string filePath)
        {
            return await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath));
        }
    }
}
