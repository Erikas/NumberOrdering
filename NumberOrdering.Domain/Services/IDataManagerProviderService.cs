using NumberOrdering.Persistence.Contracts;

namespace NumberOrdering.Domain.Services
{
    public interface IDataManagerProviderService
    {
        Task<string> ReadAsync(string filePath); 
        Task WriteAsync(string text, string filePath);
    }

    internal class DataManagerProviderService : IDataManagerProviderService
    {
        private readonly IDataManagerProvider _dataManagerProvider;
        public DataManagerProviderService(IDataManagerProvider dataManagerProvider)
        {
            _dataManagerProvider = dataManagerProvider;
        }

        public async Task<string> ReadAsync(string filePath)
        {
            return  await _dataManagerProvider.ReadAsync(filePath);
        }

        public async Task WriteAsync(string text, string fileName)
        {
            await _dataManagerProvider.WriteAsync(text, fileName);
        }
    }
}
