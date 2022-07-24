using MediatR;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Application.QueryHandlers
{
    public class TeamQueryHandler : IRequestHandler<GetTeamQuery, RequestResult<Team>>
    {
        private readonly ITeamRepository _repository;

        public TeamQueryHandler(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<RequestResult<Team>> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var teams = await _repository.Select(request.Id, request.Name, request.Cnpj, request.Location, true);
                if (!teams.Any())
                    return new RequestResult<Team>(HttpStatusCode.NotFound, new Team(), Enumerable.Empty<ErrorModel>());

                if (request.SingleData)
                {
                    var team = teams.FirstOrDefault();
                    return new RequestResult<Team>(HttpStatusCode.OK, team, Enumerable.Empty<ErrorModel>());
                }

                return new RequestResult<Team>(HttpStatusCode.OK, teams, Enumerable.Empty<ErrorModel>());
            }
            catch
            {
                return new RequestResult<Team>(HttpStatusCode.InternalServerError, new Player(), Enumerable.Empty<ErrorModel>());
            }
        }
    }
}
