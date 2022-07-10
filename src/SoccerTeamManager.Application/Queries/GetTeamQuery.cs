using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Application.Queries
{
    public class GetTeamQuery : IQuery<RequestResult<Team>>
    {
        public Guid TeamId { get; private set; }

        public GetTeamQuery(Guid teamId)
        {
            TeamId = teamId;
        }
    }
}
