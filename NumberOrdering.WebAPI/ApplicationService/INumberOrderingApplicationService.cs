using System.Net;
using NumberOrdering.Domain.Services;
using NumberOrdering.WebAPI.Infrastructure;

namespace NumberOrdering.WebAPI.ApplicationService
{
    public interface INumberOrderingApplicationService
    {
        Task ProcessAsync(IEnumerable<int> collection);
        Task<IEnumerable<int>> GetSortedIntegerCollectionAsync();
    }

    internal class NumberOrderingApplicationService : INumberOrderingApplicationService
    {
        private readonly INumberOrderingService _numberOrderingService;
        private readonly IDataManagerProviderService _dataManagerProviderService;
        private readonly IConfiguration _configuration;

        public NumberOrderingApplicationService(INumberOrderingService numberOrderingService,
            IDataManagerProviderService dataManagerProviderService,
            IConfiguration configuration)
        {
            _numberOrderingService = numberOrderingService;
            _dataManagerProviderService = dataManagerProviderService;
            _configuration = configuration;
        }

        public async Task ProcessAsync(IEnumerable<int> collection)
        {
            var resultFileName = _configuration.GetValue<string>("ResultFileName");
            var sortedCollection = _numberOrderingService.Sort(collection);
            var text = string.Join(" ", sortedCollection);
            
            await _dataManagerProviderService.WriteAsync(text, resultFileName);
        }

        public async Task<IEnumerable<int>> GetSortedIntegerCollectionAsync()
        {
            try
            {
                var resultFileName = _configuration.GetValue<string>("ResultFileName");
                var text = await _dataManagerProviderService.ReadAsync(resultFileName);

                return text.Split(" ").Select(int.Parse).ToArray() ?? throw new InvalidCastException();
            }
            catch (FileNotFoundException ex)
            {
                throw new HttpRequestException(Constants.HttpCodesErrorMessages.NotFound("File"), ex, HttpStatusCode.NotFound);
            }
            catch (InvalidCastException ex)
            {
                throw new HttpRequestException(Constants.FileErrorMessages.IncorrectContentFormat, ex, HttpStatusCode.InternalServerError);
            }
        }
    }
}
