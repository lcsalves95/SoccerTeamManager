using Microsoft.AspNetCore.Mvc;
using SoccerTeamManager.Infra.Base;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Api.Controllers.Rest
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
                HttpStatusCode.BadRequest => BadRequest(BaseController<TResponse>.GetErrorResponse(failInstance, requestResult.Errors)),
                HttpStatusCode.NotFound => NotFound(),
                HttpStatusCode.PreconditionFailed => StatusCode(412, BaseController<TResponse>.GetErrorResponse(failInstance, requestResult.Errors)),
                _ => StatusCode(500, BaseController<TResponse>.GetErrorResponse(failInstance, requestResult.Errors))
            };
        }

        private static ErrorResponse GetErrorResponse(string? instance, IEnumerable<ErrorModel> errors)
        {
            return new ErrorResponse(instance ?? string.Empty, errors);
        }
    }
}
