using AutoFixture;
using NumberOrdering.Infrastructure.Sorters.Contracts;
using Xunit;

namespace NumberOrdering.UnitTests.Sorters
{
    public class IntegerCollectionIntersectionSorterTests
    {
        private readonly IntegerCollectionIntersectionSorter _sorter = new();
        private readonly Fixture _fixture = new();



        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        [InlineData(0)]
        public void TestSort_HighNumberOfElements(int numberOfElements)
        {
            var data= _fixture.CreateMany<int>(numberOfElements).ToArray();

            var sortedCollection = _sorter.Sort(data);

            Array.Sort(data);

            Assert.Equal(data.AsEnumerable(), sortedCollection);
        }
    }
}
