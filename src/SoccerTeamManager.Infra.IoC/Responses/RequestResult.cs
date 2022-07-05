using System.Net;

namespace SoccerTeamManager.Infra.Responses
{
    public class RequestResult<TResponse>
    {
        public HttpStatusCode StatusCode { get; private set; }
        public TResponse Data { get; private set; }
        public IEnumerable<ErrorModel> Errors { get; private set; }

        public RequestResult(HttpStatusCode statusCode, TResponse data, IEnumerable<ErrorModel> errors)
        {
            StatusCode = statusCode;
            Data = data;
            Errors = errors;
        }

        public RequestResult<object?> GetGenericResponse()
        {
            return new RequestResult<object?>(StatusCode, Data, Errors);
        }
    }
}
