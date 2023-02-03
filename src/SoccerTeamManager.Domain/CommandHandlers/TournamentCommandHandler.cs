using MediatR;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Domain.CommandHandlers
{
    public class TournamentCommandHandler : IRequestHandler<InsertTournamentCommand, RequestResult<TournamentOutput>>,
                                            IRequestHandler<UpdateTournamentCommand, RequestResult<TournamentOutput>>,
                                            IRequestHandler<DeleteTournamentCommand, RequestResult<TournamentOutput>>,
                                            IRequestHandler<InsertTournamentTeamCommand, RequestResult<TournamentOutput>>
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

        public async Task<RequestResult<TournamentOutput>> Handle(InsertTournamentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = new Tournament(request.Name, request.Prize);
                tournament = await _repository.Insert(tournament);
                await _uow.Commit();
                return new RequestResult<TournamentOutput>(HttpStatusCode.Created, TournamentOutput.FromEntity(tournament), Enumerable.Empty<ErrorModel>());
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante o cadastro do jogador {request.Name}"));
                return new RequestResult<TournamentOutput>(HttpStatusCode.InternalServerError, default(TournamentOutput), _errors);
            }
        }

        public async Task<RequestResult<TournamentOutput>> Handle(UpdateTournamentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = (await _repository.Select(id: request.Id)).FirstOrDefault();
                if (tournament == null)
                    return new RequestResult<TournamentOutput>(HttpStatusCode.NotFound, default(TournamentOutput), _errors);

                tournament.UpdateName(request.Name);
                tournament.UpdatePrize(request.Prize);

                tournament = _repository.Update(tournament);
                await _uow.Commit();
                return new RequestResult<TournamentOutput>(HttpStatusCode.OK, TournamentOutput.FromEntity(tournament), Enumerable.Empty<ErrorModel>());
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante a atualização do jogador {request.Name}"));
                return new RequestResult<TournamentOutput>(HttpStatusCode.InternalServerError, default(TournamentOutput), _errors);
            }
        }

        public async Task<RequestResult<TournamentOutput>> Handle(DeleteTournamentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = (await _repository.Select(id: request.Id)).FirstOrDefault();
                if (tournament == null)
                    return new RequestResult<TournamentOutput>(HttpStatusCode.NotFound, default(TournamentOutput), _errors);
                _repository.Delete(tournament);
                await _uow.Commit();
                return new RequestResult<TournamentOutput>(HttpStatusCode.NoContent, TournamentOutput.FromEntity(tournament), _errors);
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante a exclusão do jogador de ID:{request.Id}"));
                return new RequestResult<TournamentOutput>(HttpStatusCode.InternalServerError, default(TournamentOutput), _errors);
            }
        }

        public async Task<RequestResult<TournamentOutput>> Handle(InsertTournamentTeamCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = (await _repository.Select(id: request.TournamentId)).FirstOrDefault();
                if (tournament == null)
                    return new RequestResult<TournamentOutput>(HttpStatusCode.NotFound, default(TournamentOutput), _errors);

                var tournamentTeam = new TournamentTeam(request.TournamentId, request.TeamId);

                tournamentTeam = await _repository.InsertTeam(tournamentTeam);
                await _uow.Commit();
                return new RequestResult<TournamentOutput>(HttpStatusCode.Created, TournamentOutput.FromEntity(tournament), Enumerable.Empty<ErrorModel>());
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel(
                    "InternalError",
                    $"Ocorreu um erro inesperado durante o cadastro do time de ID:[{request.TeamId}] no torneio:[{request.TournamentId}]"));
                return new RequestResult<TournamentOutput>(HttpStatusCode.InternalServerError, default(TournamentOutput), _errors);
            }
        }
    }
}
