using NumberOrdering.Persistence.Contracts;

namespace NumberOrdering.Domain.Services
{
    public interface IDataManagerProviderService
    {
        Task<string> ReadAsync(string fileName); 
        Task WriteAsync(string text, string fileName);
    }

    internal class DataManagerProviderService : IDataManagerProviderService
    {
        private readonly IDataManagerProvider _dataManagerProvider;
        public DataManagerProviderService(IDataManagerProvider dataManagerProvider)
        {
            _dataManagerProvider = dataManagerProvider;
        }

        public async Task<string> ReadAsync(string fileName)
        {
            return  await _dataManagerProvider.ReadAsync(fileName);
        }

        public async Task WriteAsync(string text, string fileName)
        {
            await _dataManagerProvider.WriteAsync(text, fileName);
        }
    }
}
