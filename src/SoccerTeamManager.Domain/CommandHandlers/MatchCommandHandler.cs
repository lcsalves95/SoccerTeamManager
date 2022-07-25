using Confluent.Kafka;
using MediatR;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Events;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.KafkaSettings;
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
        private readonly ProducerBuilder<string, string> _kafkaBuilder;

        private const string MATCH_EVENTS_TOPIC = "match-events";

        public MatchCommandHandler(ITournamentRepository tournamentRepository, IMatchRepository matchRepository, IUnitOfWork uow, ProducerBuilder<string, string> kafkaBuilder)
        {
            _tournamentRepository = tournamentRepository;
            _matchRepository = matchRepository;
            _uow = uow;
            _errors = new List<ErrorModel>();
            _kafkaBuilder = kafkaBuilder;
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
                var match = (await _matchRepository.Select(id: request.Id, tournamentId: request.TournamentId)).FirstOrDefault();
                if (match == null)
                    return new RequestResult<Match>(HttpStatusCode.NotFound, new Match(), _errors);

                match.UpdateHomeTeam(request.HomeTeamId);
                match.UpdateVisitorTeam(request.VisitorTeamId);
                match.UpdateMatchDate(request.MatchDate);

                match = _matchRepository.Update(match);
                await _uow.Commit();
                return new RequestResult<Match>(HttpStatusCode.OK, match, _errors);
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
                var match = (await _matchRepository.Select(id: request.Id, tournamentId: request.TournamentId)).FirstOrDefault();
                if (match == null)
                    return new RequestResult<Match>(HttpStatusCode.NotFound, new Match(), _errors);

                _matchRepository.Delete(match);
                await _uow.Commit();
                return new RequestResult<Match>(HttpStatusCode.NoContent, match, _errors);
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
                var match = (await _matchRepository.Select(id: request.MatchId, tournamentId: request.TournamentId)).FirstOrDefault();
                if (match == null)
                    return new RequestResult<MatchEvent>(HttpStatusCode.NotFound, new MatchEvent(), _errors);

                var matchEvent = new MatchEvent(request.MatchId, request.Type, request.TeamId, request.TimeOfOccurence);
                matchEvent = await _matchRepository.InsertEvent(matchEvent);
                await _uow.Commit();

                var producer = new ProducerWrapper(_kafkaBuilder);
                await producer.WriteMessage(MATCH_EVENTS_TOPIC, new CreatedMatchEventEvent(request.MatchId, request.Type, request.TeamId, request.TimeOfOccurence));

                return new RequestResult<MatchEvent>(HttpStatusCode.Created, matchEvent, _errors);
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante o cadastro do evento:[{request.Type}] na partida:[{request.MatchId}]"));
                return new RequestResult<MatchEvent>(HttpStatusCode.InternalServerError, new MatchEvent(), _errors);
            }
        }
    }
}
