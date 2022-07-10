using MediatR;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Application.QueryHandlers
{
    public class TeamQuerryHandler : IRequestHandler<GetTeamQuery, RequestResult<Team>>
    {
        private readonly ITeamRepository _teamRepository;
        public TeamQuerryHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<RequestResult<Team>> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            var result = await _teamRepository.GetById(request.TeamId);

            return new RequestResult<Team>(System.Net.HttpStatusCode.OK, result, Enumerable.Empty<ErrorModel>());
        }
    }
}
