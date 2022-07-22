using MediatR;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Domain.CommandHandlers
{
    public class PlayerCommandHandler : IRequestHandler<InsertPlayerCommand, RequestResult<Player>>,
                                        IRequestHandler<UpdatePlayerCommand, RequestResult<Player>>,
                                        IRequestHandler<DeletePlayerCommand, RequestResult<Player>>
    {
        private readonly IPlayerRepository _repository;
        private readonly List<ErrorModel> _messages;

        public PlayerCommandHandler(IPlayerRepository playerRepository)
        {
            _repository = playerRepository;
            _messages = new List<ErrorModel>();
        }

        public async Task<RequestResult<Player>> Handle(InsertPlayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var player = new Player(request.Name, request.DateOfBirth, request.CountryId, request.TeamId, 1000);
                player = await _repository.Insert(player);
                return new RequestResult<Player>(HttpStatusCode.Created, player, Enumerable.Empty<ErrorModel>());
            }
            catch (Exception)
            {
                _messages.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante o cadastro do jogador {request.Name}"));
                return new RequestResult<Player>(HttpStatusCode.InternalServerError, new Player(), _messages);
            }
        }

        public async Task<RequestResult<Player>> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var player = (await _repository.Select(id: request.Id)).FirstOrDefault();
                if (player == null)
                    return new RequestResult<Player>(HttpStatusCode.NotFound, new Player(), _messages);

                player.UpdateName(request.Name);
                player.UpdateCountry(request.CountryId);
                player.UpdateDateOfBirth(request.DateOfBirth);
                player.UpdateCbfCode(request.CbfCode);
                if (request.TeamId.HasValue) player.UpdateTeam(request.TeamId.Value);

                player = _repository.Update(player);

                return new RequestResult<Player>(HttpStatusCode.OK, player, Enumerable.Empty<ErrorModel>());
            }
            catch (Exception)
            {
                _messages.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante a atualização do jogador {request.Name}"));
                return new RequestResult<Player>(HttpStatusCode.InternalServerError, new Player(), _messages);
            }
        }

        public async Task<RequestResult<Player>> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var player = (await _repository.Select(id: request.Id)).FirstOrDefault();
                if (player == null)
                    return new RequestResult<Player>(HttpStatusCode.NotFound, new Player(), _messages);
                _repository.Delete(player);
                return new RequestResult<Player>(HttpStatusCode.NoContent, new Player(), _messages);
            }
            catch(Exception)
            {
                _messages.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante a exclusão do jogador de ID:{request.Id}"));
                return new RequestResult<Player>(HttpStatusCode.InternalServerError, new Player(), _messages);
            }
        }
    }
}
