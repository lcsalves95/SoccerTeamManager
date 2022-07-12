using SoccerTeamManager.Infra.Base;
using System.Net;

namespace SoccerTeamManager.Infra.Responses
{
    public class RequestResult<TResponse> where TResponse : Entity
    {
        public HttpStatusCode StatusCode { get; private set; }
        public Entity Data { get; private set; }
        public IEnumerable<ErrorModel> Errors { get; private set; }

        public RequestResult(HttpStatusCode statusCode, Entity data, IEnumerable<ErrorModel> errors)
        {
            StatusCode = statusCode;
            Data = data;
            Errors = errors;
        }

        public RequestResult<Entity> GetGenericResponse() => new(StatusCode, Data, Errors);
    }
}
