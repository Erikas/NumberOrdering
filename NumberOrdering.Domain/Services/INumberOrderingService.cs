using NumberOrdering.Infrastructure.Sorters.Contracts;

namespace NumberOrdering.Domain.Services
{
    public interface INumberOrderingService
    {
        IEnumerable<int> Sort(IEnumerable<int> collection);
    }

    internal class NumberOrderingService : INumberOrderingService
    {
        private readonly ICustomSorter<int> _customSorter;
        public NumberOrderingService(ICustomSorter<int> customArraySorter)
        {
            _customSorter = customArraySorter;
        }

        public IEnumerable<int> Sort(IEnumerable<int> collection)
        {
           return _customSorter.Sort(collection);
        }


    }
}
