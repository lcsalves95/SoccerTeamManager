using MediatR;
using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Application.QueryHandlers
{
    public class PlayerQuerryHandler : IRequestHandler<GetPlayerQuery, RequestResult<PlayerOutput>>
    {
        private readonly IPlayerRepository _repository;

        public PlayerQuerryHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<RequestResult<PlayerOutput>> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var players = await _repository.Select(request.Id, request.Name, null, null, request.Cpf, true);
                if (request.SingleData)
                {
                    var player = players.FirstOrDefault();
                    if (player == null)
                        return new RequestResult<PlayerOutput>(HttpStatusCode.NotFound, default(PlayerOutput), Enumerable.Empty<ErrorModel>());

                    return new RequestResult<PlayerOutput>(HttpStatusCode.OK, PlayerOutput.FromEntity(player), Enumerable.Empty<ErrorModel>());
                }
                var output = players.Select(p => PlayerOutput.FromEntity(p));
                return new RequestResult<PlayerOutput>(HttpStatusCode.OK, output, Enumerable.Empty<ErrorModel>());
            }
            catch
            {
                return new RequestResult<PlayerOutput>(HttpStatusCode.InternalServerError, default(PlayerOutput), Enumerable.Empty<ErrorModel>());
            }
        }
    }
}
