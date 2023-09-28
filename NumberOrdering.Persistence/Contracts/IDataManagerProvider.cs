namespace NumberOrdering.Persistence.Contracts
{
    public interface IDataManagerProvider
    {
        Task WriteAsync(string text, string fileName);
        Task<string> ReadAsync(string fileName);   

    }
}
