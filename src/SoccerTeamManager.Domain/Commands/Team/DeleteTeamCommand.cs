using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class DeleteTeamCommand : ICommand<RequestResult<Team>>
    {
        public Guid Id { get; private set; }

        public DeleteTeamCommand(Guid id)
        {
            Id = id;
        }
    }
}
