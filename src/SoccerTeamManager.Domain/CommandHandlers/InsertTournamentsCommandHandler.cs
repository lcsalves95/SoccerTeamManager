using MediatR;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.CommandHandlers
{
    public class InsertTournamentsCommandHandler : IRequestHandler<InsertTournamentsCommand, RequestResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITeamRepository _teamRepository;

        public InsertTournamentsCommandHandler(
                    IUnitOfWork unitOfWork,
                    ITournamentRepository tournamentRepository,
                    ITeamRepository teamRepository)
        {
            _unitOfWork = unitOfWork;
            _tournamentRepository = tournamentRepository;
            _teamRepository = teamRepository;
        }

        public async Task<RequestResult<bool>> Handle(InsertTournamentsCommand request, CancellationToken cancellationToken)
        {
            request.Tournaments.ToList().ForEach(t =>
            {
                var teams = new List<Team>();
                t.TeamsId.ToList().ForEach(async e =>
                {
                    var team = await _teamRepository.GetById(e);
                    teams.Add(team);
                });

                var tournament = new Tournament(t.Id.GetValueOrDefault(), t.Name, teams.ToList());

                _tournamentRepository.Insert(tournament);
            });

            if (_unitOfWork.Commit())
            {
                return new RequestResult<bool>(System.Net.HttpStatusCode.Created, true, Enumerable.Empty<ErrorModel>());
            }

            return new RequestResult<bool>(System.Net.HttpStatusCode.BadRequest, false, Enumerable.Empty<ErrorModel>());
        }
    }
}
