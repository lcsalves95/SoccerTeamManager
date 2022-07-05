using Microsoft.AspNetCore.Mvc;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult GetCustomResponse(RequestResult<object?> requestResult, string? successInstance = null, string? failInstance = null)
        {
            return requestResult.StatusCode switch
            {
                HttpStatusCode.OK => Ok(requestResult.Data),
                HttpStatusCode.Created => Created(successInstance ?? string.Empty, requestResult.Data),
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
