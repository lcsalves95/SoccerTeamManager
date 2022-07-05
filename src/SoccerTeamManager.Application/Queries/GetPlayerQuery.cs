using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Application.Queries
{
    public class GetPlayerQuery : IQuery<RequestResult<Player>>
    {
        public Guid playerId { get; private set; }

        public GetPlayerQuery(Guid playerId)
        {
            this.playerId = playerId;
        }
    }
}
