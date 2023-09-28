using System.Net;
using Microsoft.AspNetCore.Mvc;
using NumberOrdering.WebAPI.Infrastructure.Validators;
using NumberOrdering.WebAPI.ApplicationService;

namespace NumberOrdering.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberOrderingController : ControllerBase
    {
        private readonly INumberOrderingApplicationService _numberOrderingApplicationService;

        public NumberOrderingController(INumberOrderingApplicationService numberOrderingApplicationService)
        {
            _numberOrderingApplicationService = numberOrderingApplicationService;
        }

        [HttpPost("Sort")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [Produces("text/json")]
        public async Task<ActionResult> PostIntegerCollectionAsync([FromBody][IntegerArrayValidator] IEnumerable<int> collection)
        {
             await _numberOrderingApplicationService.ProcessAsync(collection);
             return Ok();
        }

        [HttpGet("SortedIntegerCollection")]
        [ProducesResponseType(typeof(IEnumerable<int>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NotFound)]
        [Produces("text/json")]
        public async Task<ActionResult<IEnumerable<int>>> GetSortedIntegerCollectionAsync()
        {
            var collection = await _numberOrderingApplicationService.ReadAsync();
            return Ok(collection);
        }
    }
}
