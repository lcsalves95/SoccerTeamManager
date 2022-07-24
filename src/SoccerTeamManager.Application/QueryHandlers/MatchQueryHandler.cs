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
        private readonly ITournamentRepository _repository;

        public MatchQueryHandler(ITournamentRepository repository)
        {
            _repository = repository;
        }

        public async Task<RequestResult<Match>> Handle(GetMatchQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = (await _repository.Select(id: request.TournamentId, includes: true)).FirstOrDefault();
                if (tournament == null)
                    return new RequestResult<Match>(HttpStatusCode.NotFound, new Match(), Enumerable.Empty<ErrorModel>());

                if (request.SingleData)
                {
                    var match = tournament?.Matches?.FirstOrDefault(x => x.Id == request.MatchId);
                    if (match == null)
                        return new RequestResult<Match>(HttpStatusCode.NotFound, new Match(), Enumerable.Empty<ErrorModel>());
                    return new RequestResult<Match>(HttpStatusCode.OK, match, Enumerable.Empty<ErrorModel>());
                }

                return new RequestResult<Match>(HttpStatusCode.OK, tournament?.Matches, Enumerable.Empty<ErrorModel>());
            }
            catch
            {
                return new RequestResult<Match>(HttpStatusCode.InternalServerError, new Match(), Enumerable.Empty<ErrorModel>());
            }
        }
    }
}
