using NumberOrdering.Persistence.Contracts;

namespace NumberOrdering.Persistence.Providers
{
    public class FileSystemDataManagerProvider : IDataManagerProvider
    {
        public async Task WriteAsync(string text, string fileName)
        {
            await using (var outputFile = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName)))
            {
                await outputFile.WriteAsync(text);
            } 
        }

        public async Task<string> ReadAsync(string fileName)
        {
            return await File.ReadAllTextAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName));
        }
    }
}
