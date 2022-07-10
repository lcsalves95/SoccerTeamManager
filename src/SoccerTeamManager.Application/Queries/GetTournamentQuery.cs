using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Application.Queries
{
    public class GetTournamentQuery : IQuery<RequestResult<Tournament>>
    {
        public Guid TournamentId { get; private set; }

        public GetTournamentQuery(Guid tournamentId)
        {
            TournamentId = tournamentId;
        }
    }
}
