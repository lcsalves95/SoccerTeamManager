using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Application.Queries
{
    public class GetTournamentTeamsQuery : IQuery<RequestResult<Team>>
    {
        public Guid TournamentId { get; private set; }

        public GetTournamentTeamsQuery(Guid tournamentId)
        {
            TournamentId = tournamentId;
        }
    }
}
