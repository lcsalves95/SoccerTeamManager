using SoccerTeamManager.Infra.Messages;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace SoccerTeamManager.Infra.PipelineBehavior
{
    [ExcludeFromCodeCoverage]
    public class DeepValidationBehavior<TRequest, TResponse> : ValidationBehavior<TRequest, TResponse>
        where TRequest : class, ICommand<TResponse>
        where TResponse : class
    {
        public DeepValidationBehavior(IEnumerable<IDeepValidator<TRequest>> validators) : base(validators, HttpStatusCode.PreconditionFailed)
        {
        }
    }
}