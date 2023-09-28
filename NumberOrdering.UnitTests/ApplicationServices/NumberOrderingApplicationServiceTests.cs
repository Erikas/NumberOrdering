using Microsoft.Extensions.Configuration;
using NSubstitute;
using NumberOrdering.Domain.Services;
using NumberOrdering.WebAPI.ApplicationService;
using Xunit;

namespace NumberOrdering.UnitTests.ApplicationServices
{
    public class NumberOrderingApplicationServiceTests
    {
        private readonly INumberOrderingApplicationService _numberOrderingApplicationService;
        private readonly IDataManagerProviderService _dataManagerProviderServiceMock;
        private readonly INumberOrderingService _numberOrderingServiceMock;


        public NumberOrderingApplicationServiceTests()
        {
            _numberOrderingServiceMock = Substitute.For<INumberOrderingService>();
            _dataManagerProviderServiceMock = Substitute.For<IDataManagerProviderService>();
            var configurationMock = Substitute.For<IConfiguration>();

            _numberOrderingApplicationService = new NumberOrderingApplicationService(_numberOrderingServiceMock, _dataManagerProviderServiceMock, configurationMock);
        }

        [Theory]
        [InlineData("0 1 3 3 4 4 7 9 9 9", 0, 1, 3, 3, 4, 4, 7, 9, 9, 9)]
        [InlineData("0 1 3 4 9", 0, 1, 3, 4, 9)]
        [InlineData("")]


        public async void TestProcessAsync_CorrectTextFormat(string expectedResult, params int[] data)
        {
            _numberOrderingServiceMock.Sort(data).Returns(data);

            await _numberOrderingApplicationService.ProcessAsync(data);

            await _dataManagerProviderServiceMock.Received().WriteAsync(expectedResult, string.Empty);
        }

        [Theory]
        [InlineData("0 1 3 3 4 4 7 9 9 9", 0, 1, 3, 3, 4, 4, 7, 9, 9, 9)]
        [InlineData("0 1 3 4 9", 0, 1, 3, 4, 9)]
        [InlineData("")]


        public async void TestGetSortedIntegerCollectionAsync_CorrectCollection(string text, params int[] expectedResult)
        {
            _dataManagerProviderServiceMock.ReadAsync(string.Empty).Returns(text);

            var result = await _numberOrderingApplicationService.GetSortedIntegerCollectionAsync();

            Assert.Equal(expectedResult, result);
        }
    }
}
