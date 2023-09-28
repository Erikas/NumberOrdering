using System.Net;
using NumberOrdering.Domain.Services;
using NumberOrdering.WebAPI.Infrastructure;

namespace NumberOrdering.WebAPI.ApplicationService
{
    public interface INumberOrderingApplicationService
    {
        Task ProcessAsync(int[] array);
        Task<int[]> ReadAsync();
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

        public async Task ProcessAsync(int[] array)
        {
            var resultFileName = _configuration.GetValue<string>("ResultFileName");
            _numberOrderingService.Sort(array);
            var text = string.Join(" ", array);
            await _dataManagerProviderService.WriteAsync(text, resultFileName);
        }

        public async Task<int[]> ReadAsync()
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
