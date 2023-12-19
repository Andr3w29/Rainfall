using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rainfall.Api.Core.Application.Common.Response.Error;
using Rainfall.Api.Core.Application.Common.Response.External;
using Rainfall.Api.Core.Application.Queries.Rainfall;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Rainfall.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class RainfallController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
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
        [SwaggerOperation(OperationId = "get-rainfall", Description = "Retrieve the latest readings for the specified stationId")]
        [ProducesResponseType(typeof(RainfallReadingResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetRainfall([FromRoute] string stationId, [FromQuery][Range(1, 100)] int count = 10)
        {
            try
            {
                var response = await Mediator.Send(new GetRainfallByStationIdQuery(stationId, count));

                if (response != null && response.Items.Count == 0)
                    return NotFound(new ErrorResponse()
                    {
                        Message = $"No readings found.",
                        ErrorDetail = new List<ErrorDetail>
                    {
                       new ErrorDetail()
                       {
                           Message=$"Readings not found for this station id {stationId}",
                           PropertyName="StatationId"
                       }
                    }

                    });


                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse()
                {
                    Message = "Internal server error. Please contact the API Team for investigation"

                });
            }


        }
    }
}
