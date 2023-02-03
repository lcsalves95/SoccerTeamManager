using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Application.Queries
{
    public class GetMatchQuery : IQuery<RequestResult<MatchOutput>>
    {
        public Guid TournamentId { get; private set; }
        public Guid? MatchId { get; private set; }
        public bool SingleData { get; private set; }

        public GetMatchQuery(Guid tournamentId, Guid? matchId = null, bool singleData = false)
        {
            TournamentId = tournamentId;
            MatchId = matchId;
            SingleData = singleData;
        }
    }
}
