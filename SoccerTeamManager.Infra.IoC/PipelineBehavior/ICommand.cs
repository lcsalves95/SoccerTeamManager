using MediatR;

namespace SoccerTeamManager.Infra.IoC.PipelineBehavior
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
