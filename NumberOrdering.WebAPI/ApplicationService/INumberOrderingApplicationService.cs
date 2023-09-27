using System.Net;
using NumberOrdering.Domain.Services;
using NumberOrdering.WebAPI.Infrastructure;

namespace NumberOrdering.WebAPI.ApplicationService
{
    public interface INumberOrderingApplicationService
    {
        Task SortAndSave(int[] array);
        Task<int[]> ReadAsync();
    }

    internal class NumberOrderingApplicationService : INumberOrderingApplicationService
    {
        private readonly INumberOrderingService _numberOrderingService;
        private readonly IConfiguration _configuration;

        public NumberOrderingApplicationService(INumberOrderingService numberOrderingService, IConfiguration configuration)
        {
            _numberOrderingService = numberOrderingService;
            _configuration = configuration;
        }

        public async Task SortAndSave(int[] array)
        {
            var resultFileName = _configuration.GetValue<string>("ResultFileName");
            await _numberOrderingService.SortAndSave(array, resultFileName);
        }

        public async Task<int[]> ReadAsync()
        {
            try
            {
                var resultFileName = _configuration.GetValue<string>("ResultFileName");
                return await _numberOrderingService.ReadAsync(resultFileName);
            }
            catch (FileNotFoundException ex)
            {
                throw new HttpRequestException(Constants.HttpCodesErrorMessages.NotFound("File"), ex, HttpStatusCode.NotFound);
            }
        }
    }
}
