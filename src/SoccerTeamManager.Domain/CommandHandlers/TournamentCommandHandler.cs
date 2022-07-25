using MediatR;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Domain.CommandHandlers
{
    public class TournamentCommandHandler : IRequestHandler<InsertTournamentCommand, RequestResult<Tournament>>,
                                            IRequestHandler<UpdateTournamentCommand, RequestResult<Tournament>>,
                                            IRequestHandler<DeleteTournamentCommand, RequestResult<Tournament>>,
                                            IRequestHandler<InsertTournamentTeamCommand, RequestResult<TournamentTeam>>
    {
        private readonly ITournamentRepository _repository;
        private readonly IUnitOfWork _uow;
        private readonly List<ErrorModel> _errors;

        public TournamentCommandHandler(ITournamentRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
            _errors = new List<ErrorModel>();
        }

        public async Task<RequestResult<Tournament>> Handle(InsertTournamentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = new Tournament(request.Name, request.Prize);
                tournament = await _repository.Insert(tournament);
                await _uow.Commit();
                return new RequestResult<Tournament>(HttpStatusCode.Created, tournament, Enumerable.Empty<ErrorModel>());
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante o cadastro do jogador {request.Name}"));
                return new RequestResult<Tournament>(HttpStatusCode.InternalServerError, new Tournament(), _errors);
            }
        }

        public async Task<RequestResult<Tournament>> Handle(UpdateTournamentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = (await _repository.Select(id: request.Id)).FirstOrDefault();
                if (tournament == null)
                    return new RequestResult<Tournament>(HttpStatusCode.NotFound, new Tournament(), _errors);

                tournament.UpdateName(request.Name);
                tournament.UpdatePrize(request.Prize);

                tournament = _repository.Update(tournament);
                await _uow.Commit();
                return new RequestResult<Tournament>(HttpStatusCode.OK, tournament, Enumerable.Empty<ErrorModel>());
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante a atualização do jogador {request.Name}"));
                return new RequestResult<Tournament>(HttpStatusCode.InternalServerError, new Tournament(), _errors);
            }
        }

        public async Task<RequestResult<Tournament>> Handle(DeleteTournamentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = (await _repository.Select(id: request.Id)).FirstOrDefault();
                if (tournament == null)
                    return new RequestResult<Tournament>(HttpStatusCode.NotFound, new Tournament(), _errors);
                _repository.Delete(tournament);
                await _uow.Commit();
                return new RequestResult<Tournament>(HttpStatusCode.NoContent, tournament, _errors);
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante a exclusão do jogador de ID:{request.Id}"));
                return new RequestResult<Tournament>(HttpStatusCode.InternalServerError, new Tournament(), _errors);
            }
        }

        public async Task<RequestResult<TournamentTeam>> Handle(InsertTournamentTeamCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = (await _repository.Select(id: request.TournamentId)).FirstOrDefault();
                if (tournament == null)
                    return new RequestResult<TournamentTeam>(HttpStatusCode.NotFound, new TournamentTeam(), _errors);

                var tournamentTeam = new TournamentTeam(request.TournamentId, request.TeamId);

                tournamentTeam = await _repository.InsertTeam(tournamentTeam);
                await _uow.Commit();
                return new RequestResult<TournamentTeam>(HttpStatusCode.Created, tournamentTeam, Enumerable.Empty<ErrorModel>());
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel(
                    "InternalError",
                    $"Ocorreu um erro inesperado durante o cadastro do time de ID:[{request.TeamId}] no torneio:[{request.TournamentId}]"));
                return new RequestResult<TournamentTeam>(HttpStatusCode.InternalServerError, new TournamentTeam(), _errors);
            }
        }
    }
}
