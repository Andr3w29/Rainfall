using Microsoft.AspNetCore.Mvc;
using Rainfall.Api.Core.Application.Common.Response.External;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Rainfall.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class RainfallController : ControllerBase
    {

        /// <summary>
        /// Get rainfall readings by station Id
        /// </summary>
        /// <param name="stationId">The id of the reading station</param>
        /// <param name="count"> The number of readings to return</param>
        /// <returns>Retrieve the latest readings for the specified stationId </returns>
        /// <response code="200">A list of rainfall readings successfully retrieved</response>
        /// <response code="400"> Invalid request</response>
        /// <response code="404">No readings found for the specified stationId</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        [Route("id/{stationId}/readings")]
        [SwaggerOperation(Tags = new[] { "get-rainfall" })]
        [ProducesResponseType(typeof(RainfallReadingResponse), StatusCodes.Status200OK)]
        public IActionResult GetRainfall([FromRoute] string stationId, [FromQuery][Range(1, 100)] int count = 10)
        {
            return Ok("ok");
        }
    }
}
