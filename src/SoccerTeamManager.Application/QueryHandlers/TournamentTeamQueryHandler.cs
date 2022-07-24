using MediatR;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTeamManager.Application.QueryHandlers
{
    public class TournamentTeamQueryHandler : IRequestHandler<GetTournamentTeamsQuery, RequestResult<Team>>
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITeamRepository _teamRepository;

        public TournamentTeamQueryHandler(ITeamRepository teamRepository, ITournamentRepository tournamentRepository)
        {
            _teamRepository = teamRepository;
            _tournamentRepository = tournamentRepository;
        }

        public async Task<RequestResult<Team>> Handle(GetTournamentTeamsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var tournament = (await _tournamentRepository.Select(request.TournamentId)).FirstOrDefault();
                if (tournament == null)
                    return new RequestResult<Team>(HttpStatusCode.NotFound, new Team(), Enumerable.Empty<ErrorModel>());

                var tournamentTeams = await _tournamentRepository.SelectTournamentTeams(tournament.Id);
                var teams = new List<Team>();
                foreach(var tournamentTeam in tournamentTeams)
                {
                    var team = (await _teamRepository.Select(id: tournamentTeam.TeamId)).First();
                    teams.Add(team);
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
