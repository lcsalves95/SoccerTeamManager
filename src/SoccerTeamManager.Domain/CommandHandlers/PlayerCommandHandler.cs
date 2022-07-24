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
        private readonly IUnitOfWork _uow;
        private readonly List<ErrorModel> _errors;

        public PlayerCommandHandler(IPlayerRepository playerRepository, IUnitOfWork uow)
        {
            _repository = playerRepository;
            _uow = uow;
            _errors = new List<ErrorModel>();
        }

        public async Task<RequestResult<Player>> Handle(InsertPlayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var player = new Player(request.Name, request.DateOfBirth, request.CountryId, request.TeamId, request.Cpf);
                player = await _repository.Insert(player);
                await _uow.Commit();
                return new RequestResult<Player>(HttpStatusCode.Created, player, Enumerable.Empty<ErrorModel>());
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante o cadastro do jogador {request.Name}"));
                return new RequestResult<Player>(HttpStatusCode.InternalServerError, new Player(), _errors);
            }
        }

        public async Task<RequestResult<Player>> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var player = (await _repository.Select(id: request.Id)).FirstOrDefault();
                if (player == null)
                    return new RequestResult<Player>(HttpStatusCode.NotFound, new Player(), _errors);

                player.UpdateName(request.Name);
                player.UpdateCountry(request.CountryId);
                player.UpdateDateOfBirth(request.DateOfBirth);
                if (request.TeamId.HasValue) player.UpdateTeam(request.TeamId.Value);

                player = _repository.Update(player);
                await _uow.Commit();
                return new RequestResult<Player>(HttpStatusCode.OK, player, Enumerable.Empty<ErrorModel>());
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante a atualização do jogador {request.Name}"));
                return new RequestResult<Player>(HttpStatusCode.InternalServerError, new Player(), _errors);
            }
        }

        public async Task<RequestResult<Player>> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var player = (await _repository.Select(id: request.Id)).FirstOrDefault();
                if (player == null)
                    return new RequestResult<Player>(HttpStatusCode.NotFound, new Player(), _errors);
                _repository.Delete(player);
                await _uow.Commit();
                return new RequestResult<Player>(HttpStatusCode.NoContent, new Player(), _errors);
            }
            catch(Exception)
            {
                _errors.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante a exclusão do jogador de ID:{request.Id}"));
                return new RequestResult<Player>(HttpStatusCode.InternalServerError, new Player(), _errors);
            }
        }
    }
}
