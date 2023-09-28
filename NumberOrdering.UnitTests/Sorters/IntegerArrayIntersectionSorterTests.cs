using AutoFixture;
using NumberOrdering.Infrastructure.Sorters.Contracts;
using Xunit;

namespace NumberOrdering.UnitTests.Sorters
{
    public class IntegerArrayIntersectionSorterTests
    {
        private readonly IntegerArrayIntersectionSorter _sorter = new();
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

            var originalArray = new int[data.Length];
            data.CopyTo(originalArray, 0);
            Array.Sort(originalArray);

            _sorter.Sort(data);

            Assert.Equal(originalArray, data);
        }
    }
}
