using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class DeletePlayerCommand : ICommand<RequestResult<Player>>
    {
        public Guid Id { get; private set; }

        public DeletePlayerCommand(Guid id)
        {
            Id = id;
        }
    }
}
