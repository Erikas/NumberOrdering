namespace NumberOrdering.Infrastructure.Sorters.Contracts
{
    public class IntegerCollectionIntersectionSorter : ICustomSorter<int>
    {
        public IEnumerable<int> Sort(IEnumerable<int> collection)
        {
            var array = collection.ToArray();

            var arrayLength = array.Length;


            for (var i = 1;i < arrayLength; i++)
            {
                var currentItem = array[i];
                var previousIndexIterator = i - 1;

                while (previousIndexIterator >= 0 && currentItem < array[previousIndexIterator])
                {
                    array[previousIndexIterator + 1] = array[previousIndexIterator];
                    array[previousIndexIterator] = currentItem;
                    previousIndexIterator--;
                }
            }

            return array;
        }
    }
}
