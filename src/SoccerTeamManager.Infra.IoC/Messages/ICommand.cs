using MediatR;

namespace SoccerTeamManager.Infra.Messages
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
