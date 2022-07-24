using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertTournamentTeamCommand : ICommand<RequestResult<TournamentTeam>>
    {
        public Guid TournamentId { get; private set; }
        public Guid TeamId { get; private set; }

        public InsertTournamentTeamCommand(Guid tournamentId, Guid teamId)
        {
            TournamentId = tournamentId;
            TeamId = teamId;
        }
    }
}
