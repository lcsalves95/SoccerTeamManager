using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class DeleteMatchCommand : ICommand<RequestResult<Match>>
    {
        public Guid Id { get; private set; }
        public Guid TournamentId { get; private set; }

        public DeleteMatchCommand(Guid id, Guid tournamentId)
        {
            Id = id;
            TournamentId = tournamentId;
        }
    }
}
