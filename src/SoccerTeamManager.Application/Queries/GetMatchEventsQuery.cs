using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Application.Queries
{
    public class GetMatchEventsQuery : IQuery<RequestResult<MatchEvent>>
    {
        public Guid TournamentId { get; private set; }
        public Guid MatchId { get; private set; }

        public GetMatchEventsQuery(Guid tournamentId, Guid matchId)
        {
            TournamentId = tournamentId;
            MatchId = matchId;
        }
    }
}
