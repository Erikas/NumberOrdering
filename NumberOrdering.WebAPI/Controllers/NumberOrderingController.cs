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
        [ProducesResponseType(typeof(int[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [Produces("text/json")]
        public async Task<ActionResult> PostIntegerArrayAsync([FromBody][IntegerArrayValidator] int[] array)
        {
             await _numberOrderingApplicationService.SortAndSave(array);
             return Ok(array);
        }

        [HttpGet("SortedIntegerArray")]
        [ProducesResponseType(typeof(int[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NotFound)]
        [Produces("text/json")]
        public async Task<ActionResult> GetSortedIntegerArrayAsync()
        {
            var array = await _numberOrderingApplicationService.ReadAsync();
            return Ok(array);
        }
    }
}
