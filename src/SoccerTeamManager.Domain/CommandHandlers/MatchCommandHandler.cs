using MediatR;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Domain.CommandHandlers
{
    public class MatchCommandHandler : IRequestHandler<InsertMatchCommand, RequestResult<MatchOutput>>,
                                       IRequestHandler<UpdateMatchCommand, RequestResult<MatchOutput>>,
                                       IRequestHandler<DeleteMatchCommand, RequestResult<MatchOutput>>
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IUnitOfWork _uow;
        private readonly List<ErrorModel> _errors;

        public MatchCommandHandler(ITournamentRepository tournamentRepository, IMatchRepository matchRepository, IUnitOfWork uow)
        {
            _tournamentRepository = tournamentRepository;
            _matchRepository = matchRepository;
            _uow = uow;
            _errors = new List<ErrorModel>();
        }

        public async Task<RequestResult<MatchOutput>> Handle(InsertMatchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = (await _tournamentRepository.Select(id: request.TournamentId, includes: true)).FirstOrDefault();
                if (tournament == null)
                    return new RequestResult<MatchOutput>(HttpStatusCode.NotFound, default(MatchOutput), _errors);

                var match = new Match(request.TournamentId, request.HomeTeamId, request.VisitorTeamId, request.MatchDate);

                match = await _matchRepository.Insert(match);
                await _uow.Commit();
                return new RequestResult<MatchOutput>(HttpStatusCode.Created, MatchOutput.FromEntity(match), _errors);
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", "Ocorreu um erro inesperado durante o cadastro da partida"));
                return new RequestResult<MatchOutput>(HttpStatusCode.InternalServerError, default(MatchOutput), _errors);
            }
        }

        public async Task<RequestResult<MatchOutput>> Handle(UpdateMatchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var match = (await _matchRepository.Select(id: request.Id, tournamentId: request.TournamentId)).FirstOrDefault();
                if (match == null)
                    return new RequestResult<MatchOutput>(HttpStatusCode.NotFound, default(MatchOutput), _errors);

                match.UpdateHomeTeam(request.HomeTeamId);
                match.UpdateVisitorTeam(request.VisitorTeamId);
                match.UpdateMatchDate(request.MatchDate);

                match = _matchRepository.Update(match);
                await _uow.Commit();
                return new RequestResult<MatchOutput>(HttpStatusCode.OK, MatchOutput.FromEntity(match), _errors);
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", "Ocorreu um erro inesperado durante o cadastro da partida"));
                return new RequestResult<MatchOutput>(HttpStatusCode.InternalServerError, default(MatchOutput), _errors);
            }
        }

        public async Task<RequestResult<MatchOutput>> Handle(DeleteMatchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var match = (await _matchRepository.Select(id: request.Id, tournamentId: request.TournamentId)).FirstOrDefault();
                if (match == null)
                    return new RequestResult<MatchOutput>(HttpStatusCode.NotFound, default(MatchOutput), _errors);

                _matchRepository.Delete(match);
                await _uow.Commit();
                return new RequestResult<MatchOutput>(HttpStatusCode.NoContent, MatchOutput.FromEntity(match), _errors);
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", "Ocorreu um erro inesperado durante o cadastro da partida"));
                return new RequestResult<MatchOutput>(HttpStatusCode.InternalServerError, default(MatchOutput), _errors);
            }
        }
    }
}
