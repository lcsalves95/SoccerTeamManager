using MediatR;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Application.QueryHandlers
{
    public class TournamentQueryHandler : IRequestHandler<GetTournamentQuery, RequestResult<TournamentOutput>>
    {
        private readonly ITournamentRepository _repository;

        public TournamentQueryHandler(ITournamentRepository repository)
        {
            _repository = repository;
        }

        public async Task<RequestResult<TournamentOutput>> Handle(GetTournamentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tournaments = await _repository.Select(request.Id, request.Name, true);

                if (request.SingleData)
                {
                    var tournament = tournaments.FirstOrDefault();
                    if (tournament == null)
                        return new RequestResult<TournamentOutput>(HttpStatusCode.NotFound, default(TournamentOutput), Enumerable.Empty<ErrorModel>());
                    return new RequestResult<TournamentOutput>(HttpStatusCode.OK, TournamentOutput.FromEntity(tournament), Enumerable.Empty<ErrorModel>());
                }
                var output = tournaments.Select(t => TournamentOutput.FromEntity(t));
                return new RequestResult<TournamentOutput>(HttpStatusCode.OK, output, Enumerable.Empty<ErrorModel>());
            }
            catch
            {
                return new RequestResult<TournamentOutput>(HttpStatusCode.InternalServerError, default(TournamentOutput), Enumerable.Empty<ErrorModel>());
            }
        }
    }
}
