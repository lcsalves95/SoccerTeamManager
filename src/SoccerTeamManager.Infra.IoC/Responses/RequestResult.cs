using SoccerTeamManager.Infra.Base;
using System.Net;

namespace SoccerTeamManager.Infra.Responses
{
    public class RequestResult<TResponse> where TResponse : Entity
    {
        public HttpStatusCode StatusCode { get; private set; }
        public Entity? Data { get; private set; }
        public IEnumerable<Entity>? MultipleData { get; private set; }
        public IEnumerable<ErrorModel> Errors { get; private set; }

        public RequestResult(HttpStatusCode statusCode, Entity? data, IEnumerable<ErrorModel> errors)
        {
            StatusCode = statusCode;
            Data = data;
            Errors = errors;
            MultipleData = null;
        }

        public RequestResult(HttpStatusCode statusCode, IEnumerable<Entity>? multipleData, IEnumerable<ErrorModel> errors)
        {
            StatusCode = statusCode;
            Data = null;
            Errors = errors;
            MultipleData = multipleData;
        }
    }
}
