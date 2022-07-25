using MediatR;

namespace SoccerTeamManager.Infra.Messages
{
    public interface IEvent : IRequest<bool>
    {
    }
}
