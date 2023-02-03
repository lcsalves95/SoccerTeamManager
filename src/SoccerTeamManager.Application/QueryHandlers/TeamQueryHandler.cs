using MediatR;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Application.QueryHandlers
{
    public class TeamQueryHandler : IRequestHandler<GetTeamQuery, RequestResult<TeamOutput>>
    {
        private readonly ITeamRepository _repository;

        public TeamQueryHandler(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<RequestResult<TeamOutput>> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var teams = await _repository.Select(request.Id, request.Name, request.Cnpj, request.Location, true);

                if (request.SingleData)
                {
                    var team = teams.FirstOrDefault();
                    if (team == null)
                        return new RequestResult<TeamOutput>(HttpStatusCode.NotFound, default(TeamOutput), Enumerable.Empty<ErrorModel>());
                    return new RequestResult<TeamOutput>(HttpStatusCode.OK, TeamOutput.FromEntity(team), Enumerable.Empty<ErrorModel>());
                }
                var output = teams.Select(t => TeamOutput.FromEntity(t));
                return new RequestResult<TeamOutput>(HttpStatusCode.OK, output, Enumerable.Empty<ErrorModel>());
            }
            catch
            {
                return new RequestResult<TeamOutput>(HttpStatusCode.InternalServerError, default(TeamOutput), Enumerable.Empty<ErrorModel>());
            }
        }
    }
}
