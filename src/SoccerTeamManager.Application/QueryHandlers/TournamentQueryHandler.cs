using MediatR;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Application.QueryHandlers
{
    public class TournamentQueryHandler : IRequestHandler<GetTournamentQuery, RequestResult<Tournament>>
    {
        private readonly ITournamentRepository _repository;

        public TournamentQueryHandler(ITournamentRepository repository)
        {
            _repository = repository;
        }

        public async Task<RequestResult<Tournament>> Handle(GetTournamentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tournaments = await _repository.Select(request.Id, request.Name, true);

                if (request.SingleData)
                {
                    var tournament = tournaments.FirstOrDefault();
                    if (tournament == null)
                        return new RequestResult<Tournament>(HttpStatusCode.NotFound, new Tournament(), Enumerable.Empty<ErrorModel>());
                    return new RequestResult<Tournament>(HttpStatusCode.OK, tournament, Enumerable.Empty<ErrorModel>());
                }

                return new RequestResult<Tournament>(HttpStatusCode.OK, tournaments, Enumerable.Empty<ErrorModel>());
            }
            catch
            {
                return new RequestResult<Tournament>(HttpStatusCode.InternalServerError, new Tournament(), Enumerable.Empty<ErrorModel>());
            }
        }
    }
}
