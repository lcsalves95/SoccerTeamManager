using MediatR;

namespace SoccerTeamManager.Infra.Messages
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
