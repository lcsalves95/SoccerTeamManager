using Microsoft.AspNetCore.Mvc;
using SoccerTeamManager.Infra.Base;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Api.Controllers
{
    public class BaseController<TResponse> : ControllerBase
        where TResponse : Entity
    {
        protected IActionResult GetCustomResponse(RequestResult<TResponse> requestResult, string? successInstance = null, string? failInstance = null)
        {
            return requestResult.StatusCode switch
            {
                HttpStatusCode.OK => Ok(requestResult.Data),
                HttpStatusCode.Created => CreatedAtAction(successInstance ?? string.Empty, new { requestResult.Data.Id }, requestResult.Data),
                HttpStatusCode.NoContent => NoContent(),
                HttpStatusCode.BadRequest => BadRequest(GetErrorResponse(failInstance ?? string.Empty, requestResult.Errors)),
                HttpStatusCode.NotFound => NotFound(),
                HttpStatusCode.PreconditionFailed => StatusCode(412, GetErrorResponse(failInstance ?? string.Empty, requestResult.Errors)),
                _ => StatusCode(500, GetErrorResponse(failInstance ?? string.Empty, requestResult.Errors))
            };
        }

        private ErrorResponse GetErrorResponse(string instance, IEnumerable<ErrorModel> errors)
        {
            return new ErrorResponse(instance, errors);
        }
    }
}
