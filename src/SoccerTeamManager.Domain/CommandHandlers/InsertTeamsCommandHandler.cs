using MediatR;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.CommandHandlers
{
    public class InsertTeamsCommandHandler : IRequestHandler<InsertTeamsCommand, RequestResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITeamRepository _teamRepository;

        public InsertTeamsCommandHandler(
                    IUnitOfWork unitOfWork,
                    ITeamRepository teamRepository)
        {
            _unitOfWork = unitOfWork;
            _teamRepository = teamRepository;
        }

        public async Task<RequestResult<bool>> Handle(InsertTeamsCommand request, CancellationToken cancellationToken)
        {
            request.Teams.ToList().ForEach(t =>
            {
                var team = new Team(t.Id.GetValueOrDefault(), t.Name, t.Location);

                _teamRepository.Insert(team);
            });

            if (_unitOfWork.Commit())
            {
                return new RequestResult<bool>(System.Net.HttpStatusCode.Created, true, Enumerable.Empty<ErrorModel>());
            }

            return new RequestResult<bool>(System.Net.HttpStatusCode.BadRequest, false, Enumerable.Empty<ErrorModel>());
        }
    }
}
