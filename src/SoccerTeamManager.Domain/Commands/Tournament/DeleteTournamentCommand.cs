using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class DeleteTournamentCommand : ICommand<RequestResult<Tournament>>
    {
        public Guid Id { get; private set; }

        public DeleteTournamentCommand(Guid id)
        {
            Id = id;
        }
    }
}
