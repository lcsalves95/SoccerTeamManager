using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.IoC.PipelineBehavior;

namespace SoccerTeamManager.Application.Queries
{
    public class GetPlayerQuery : IQuery<Player>
    {
        public Guid playerId { get; private set; }

        public GetPlayerQuery(Guid playerId)
        {
            this.playerId = playerId;
        }
    }
}
