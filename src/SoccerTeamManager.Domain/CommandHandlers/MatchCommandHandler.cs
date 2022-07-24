using MediatR;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Domain.CommandHandlers
{
    public class MatchCommandHandler : IRequestHandler<InsertMatchCommand, RequestResult<Match>>,
                                       IRequestHandler<UpdateMatchCommand, RequestResult<Match>>,
                                       IRequestHandler<DeleteMatchCommand, RequestResult<Match>>,
                                       IRequestHandler<InsertMatchEventCommand, RequestResult<MatchEvent>>
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

        public async Task<RequestResult<Match>> Handle(InsertMatchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = (await _tournamentRepository.Select(id: request.TournamentId, includes: true)).FirstOrDefault();
                if (tournament == null)
                    return new RequestResult<Match>(HttpStatusCode.NotFound, new Match(), _errors);

                var match = new Match(request.TournamentId, request.HomeTeamId, request.VisitorTeamId, request.MatchDate);

                match = await _matchRepository.Insert(match);
                await _uow.Commit();
                return new RequestResult<Match>(HttpStatusCode.Created, tournament, _errors);
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", "Ocorreu um erro inesperado durante o cadastro da partida"));
                return new RequestResult<Match>(HttpStatusCode.InternalServerError, new Match(), _errors);
            }
        }

        public async Task<RequestResult<Match>> Handle(UpdateMatchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = (await _tournamentRepository.Select(id: request.TournamentId, includes: true)).FirstOrDefault();
                if (tournament == null)
                    return new RequestResult<Match>(HttpStatusCode.NotFound, new Match(), _errors);

                var match = tournament.Matches?.FirstOrDefault(x => x.Id == request.Id);
                if (match == null)
                    return new RequestResult<Match>(HttpStatusCode.NotFound, new Match(), _errors);

                match.UpdateHomeTeam(request.HomeTeamId);
                match.UpdateVisitorTeam(request.VisitorTeamId);
                match.UpdateMatchDate(request.MatchDate);

                match = _matchRepository.Update(match);
                await _uow.Commit();
                return new RequestResult<Match>(HttpStatusCode.OK, tournament, _errors);
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", "Ocorreu um erro inesperado durante o cadastro da partida"));
                return new RequestResult<Match>(HttpStatusCode.InternalServerError, new Match(), _errors);
            }
        }

        public async Task<RequestResult<Match>> Handle(DeleteMatchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = (await _tournamentRepository.Select(id: request.TournamentId, includes: true)).FirstOrDefault();
                if (tournament == null)
                    return new RequestResult<Match>(HttpStatusCode.NotFound, new Match(), _errors);

                var match = tournament.Matches?.FirstOrDefault(x => x.Id == request.Id);
                if (match == null)
                    return new RequestResult<Match>(HttpStatusCode.NotFound, new Match(), _errors);

                _matchRepository.Delete(match);
                await _uow.Commit();
                return new RequestResult<Match>(HttpStatusCode.Created, tournament, _errors);
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", "Ocorreu um erro inesperado durante o cadastro da partida"));
                return new RequestResult<Match>(HttpStatusCode.InternalServerError, new Match(), _errors);
            }
        }

        public async Task<RequestResult<MatchEvent>> Handle(InsertMatchEventCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = (await _tournamentRepository.Select(id: request.TournamentId, includes: true)).FirstOrDefault();
                if (tournament == null)
                    return new RequestResult<MatchEvent>(HttpStatusCode.NotFound, new MatchEvent(), _errors);

                var match = tournament.Matches?.FirstOrDefault(x => x.Id == request.MatchId);
                if (match == null)
                    return new RequestResult<MatchEvent>(HttpStatusCode.NotFound, new MatchEvent(), _errors);

                var matchEvent = new MatchEvent(request.MatchId, request.Type, request.TeamId, request.TimeOfOccurence);
                matchEvent = await _matchRepository.InsertEvent(matchEvent);
                await _uow.Commit();

                return new RequestResult<MatchEvent>(HttpStatusCode.OK, tournament, _errors);
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante o cadastro do evento:[{request.Type}] na partida:[{request.MatchId}]"));
                return new RequestResult<MatchEvent>(HttpStatusCode.InternalServerError, new MatchEvent(), _errors);
            }
        }
    }
}
