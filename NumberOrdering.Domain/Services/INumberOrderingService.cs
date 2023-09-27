using NumberOrdering.Infrastructure.Sorters.Contracts;
using NumberOrdering.Persistence.Contracts;

namespace NumberOrdering.Domain.Services
{
    public interface INumberOrderingService
    {
        Task SortAndSave(int[] array, string resultFileName);
        Task<int[]> ReadAsync(string resultFileName);
    }

    internal class NumberOrderingService : INumberOrderingService
    {
        private readonly ICustomArraySorter<int> _customArraySorter;
        private readonly IDataManagerProvider _dataManagerProvider;
        public NumberOrderingService(ICustomArraySorter<int> customArraySorter,
            IDataManagerProvider dataManagerProvider)
        {
            _customArraySorter = customArraySorter;
            _dataManagerProvider = dataManagerProvider;
        }

        public async Task SortAndSave(int[] array, string resultFileName)
        {
            _customArraySorter.Sort(array);

            var result = string.Join(" ", array);

            await _dataManagerProvider.WriteAsync(result, resultFileName);
        }

        public async Task<int[]> ReadAsync(string filePath)
        {
            var text = await _dataManagerProvider.ReadAsync(filePath);
             return text.Split(" ").Select(int.Parse).ToArray() ?? throw new InvalidCastException();

        }
    }
}
