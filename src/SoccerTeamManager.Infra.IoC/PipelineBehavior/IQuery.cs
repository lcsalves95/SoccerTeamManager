using MediatR;

namespace SoccerTeamManager.Infra.IoC.PipelineBehavior
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
