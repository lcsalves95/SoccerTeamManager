using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Application.Queries
{
    public class GetGameQuery : IQuery<RequestResult<Game>>
    {
        public Guid GameId { get; private set; }

        public GetGameQuery(Guid gameId)
        {
            GameId = gameId;
        }
    }
}
