using MediatR;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Application.QueryHandlers
{
    public class MatchQueryHandler : IRequestHandler<GetMatchQuery, RequestResult<Match>>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly ITournamentRepository _tournamentRepository;

        public MatchQueryHandler(IMatchRepository repository, ITournamentRepository tournamentRepository)
        {
            _matchRepository = repository;
            _tournamentRepository = tournamentRepository;
        }

        public async Task<RequestResult<Match>> Handle(GetMatchQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = (await _tournamentRepository.Select(id: request.TournamentId)).FirstOrDefault();
                if (tournament == null)
                    return new RequestResult<Match>(HttpStatusCode.NotFound, new Match(), Enumerable.Empty<ErrorModel>());

                var matches = await _matchRepository.Select(tournamentId: request.TournamentId, includes: true);

                if (request.SingleData)
                {
                    var match = matches.FirstOrDefault(x => x.Id == request.MatchId);
                    if (match == null)
                        return new RequestResult<Match>(HttpStatusCode.NotFound, new Match(), Enumerable.Empty<ErrorModel>());
                    return new RequestResult<Match>(HttpStatusCode.OK, match, Enumerable.Empty<ErrorModel>());
                }

                return new RequestResult<Match>(HttpStatusCode.OK, matches, Enumerable.Empty<ErrorModel>());
            }
            catch
            {
                return new RequestResult<Match>(HttpStatusCode.InternalServerError, new Match(), Enumerable.Empty<ErrorModel>());
            }
        }
    }
}
