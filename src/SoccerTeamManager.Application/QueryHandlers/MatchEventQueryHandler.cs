using MediatR;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Application.QueryHandlers
{
    public class MatchEventQueryHandler : IRequestHandler<GetMatchEventsQuery, RequestResult<MatchEvent>>
    {
        private readonly IMatchRepository _matchRepository;

        public MatchEventQueryHandler(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<RequestResult<MatchEvent>> Handle(GetMatchEventsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var match = (await _matchRepository.Select(id: request.MatchId, tournamentId: request.TournamentId, includes: true)).FirstOrDefault();
                if (match == null)
                    return new RequestResult<MatchEvent>(HttpStatusCode.NotFound, new MatchEvent(), Enumerable.Empty<ErrorModel>());

                var events = await _matchRepository.SelectEvent(match.Id);
                return new RequestResult<MatchEvent>(HttpStatusCode.OK, events, Enumerable.Empty<ErrorModel>());
            }
            catch
            {
                return new RequestResult<MatchEvent>(HttpStatusCode.InternalServerError, new MatchEvent(), Enumerable.Empty<ErrorModel>());
            }
        }
    }
}
