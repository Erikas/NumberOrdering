namespace NumberOrdering.Persistence.Contracts
{
    public interface IDataManagerProvider
    {
        Task WriteAsync(string text, string filePath);
        Task<string> ReadAsync(string filePath);   

    }
}
