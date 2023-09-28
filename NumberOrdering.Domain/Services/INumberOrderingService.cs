using NumberOrdering.Infrastructure.Sorters.Contracts;
using NumberOrdering.Persistence.Contracts;

namespace NumberOrdering.Domain.Services
{
    public interface INumberOrderingService
    {
        void Sort(int[] array);
    }

    internal class NumberOrderingService : INumberOrderingService
    {
        private readonly ICustomArraySorter<int> _customArraySorter;
        public NumberOrderingService(ICustomArraySorter<int> customArraySorter)
        {
            _customArraySorter = customArraySorter;
        }

        public void Sort(int[] array)
        {
            _customArraySorter.Sort(array);
        }


    }
}
