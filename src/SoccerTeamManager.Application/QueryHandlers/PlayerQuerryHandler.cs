using MediatR;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Application.QueryHandlers
{
    public class PlayerQuerryHandler : IRequestHandler<GetPlayerQuery, RequestResult<Player>>
    {
        public PlayerQuerryHandler()
        {

        }

        public async Task<RequestResult<Player>> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
        {
            return new RequestResult<Player>(System.Net.HttpStatusCode.Created, new Player("Teste", DateTime.Now.AddYears(-20), Guid.NewGuid(), Guid.Empty, 1000), Enumerable.Empty<ErrorModel>());
        }
    }
}
