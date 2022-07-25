using MediatR;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Application.QueryHandlers
{
    public class PlayerQuerryHandler : IRequestHandler<GetPlayerQuery, RequestResult<Player>>
    {
        private readonly IPlayerRepository _repository;

        public PlayerQuerryHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<RequestResult<Player>> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var players = await _repository.Select(request.Id, request.Name, null, null, request.Cpf, true);
                if (request.SingleData)
                {
                    var player = players.FirstOrDefault();
                    return new RequestResult<Player>(HttpStatusCode.OK, player, Enumerable.Empty<ErrorModel>());
                }

                return new RequestResult<Player>(HttpStatusCode.OK, players, Enumerable.Empty<ErrorModel>());
            }
            catch
            {
                return new RequestResult<Player>(HttpStatusCode.InternalServerError, new Player(), Enumerable.Empty<ErrorModel>());
            }
        }
    }
}
