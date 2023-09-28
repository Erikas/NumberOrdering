namespace NumberOrdering.Infrastructure.Sorters.Contracts
{
    public interface ICustomSorter<T> where T : struct, IComparable, IFormattable, IConvertible
    {
        IEnumerable<T> Sort(IEnumerable<T> collection);
    }
}
