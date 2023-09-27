namespace NumberOrdering.Infrastructure.Sorters.Contracts
{
    public interface ICustomArraySorter<in T>
    {
        void Sort(T[] array);
    }
}
