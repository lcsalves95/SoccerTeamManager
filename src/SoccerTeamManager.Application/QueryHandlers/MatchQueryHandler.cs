using MediatR;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Application.QueryHandlers
{
    public class MatchQueryHandler : IRequestHandler<GetMatchQuery, RequestResult<MatchOutput>>
    {
        private readonly IMatchRepository _matchRepository;
        private readonly ITournamentRepository _tournamentRepository;

        public MatchQueryHandler(IMatchRepository repository, ITournamentRepository tournamentRepository)
        {
            _matchRepository = repository;
            _tournamentRepository = tournamentRepository;
        }

        public async Task<RequestResult<MatchOutput>> Handle(GetMatchQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = (await _tournamentRepository.Select(id: request.TournamentId)).FirstOrDefault();
                if (tournament == null)
                    return new RequestResult<MatchOutput>(HttpStatusCode.NotFound, default(MatchOutput), Enumerable.Empty<ErrorModel>());

                var matches = await _matchRepository.Select(tournamentId: request.TournamentId, includes: true);

                if (request.SingleData)
                {
                    var match = matches.FirstOrDefault(x => x.Id == request.MatchId);
                    if (match == null)
                        return new RequestResult<MatchOutput>(HttpStatusCode.NotFound, default(MatchOutput), Enumerable.Empty<ErrorModel>());
                    return new RequestResult<MatchOutput>(HttpStatusCode.OK, MatchOutput.FromEntity(match), Enumerable.Empty<ErrorModel>());
                }
                var output = matches.Select(m => MatchOutput.FromEntity(m));
                return new RequestResult<MatchOutput>(HttpStatusCode.OK, output, Enumerable.Empty<ErrorModel>());
            }
            catch
            {
                return new RequestResult<MatchOutput>(HttpStatusCode.InternalServerError, default(MatchOutput), Enumerable.Empty<ErrorModel>());
            }
        }
    }
}
