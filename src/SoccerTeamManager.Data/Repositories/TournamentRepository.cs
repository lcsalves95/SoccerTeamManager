using Microsoft.EntityFrameworkCore;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Data.Contexts;

namespace SoccerTeamManager.Infra.Data.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly ApplicationDbContext _context;

        public TournamentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Tournament tournament)
        {
            _context.Remove(tournament);
        }

        public async Task<Tournament> Insert(Tournament tournament)
        {
            var insertResult = await _context.Tournaments.AddAsync(tournament);
            return insertResult.Entity;
        }

        public async Task<IEnumerable<Tournament>> Select(Guid? id = null, string? name = null, bool includes = false)
        {
            var tournaments = _context.Tournaments.Where(tournament =>
                    tournament.Id == (id ?? tournament.Id) &&
                    tournament.Name == (name ?? tournament.Name)
                );
            if (includes)
            {
                tournaments.Include(x => x.Matches);
                tournaments.Include(x => x.TournamentTeams);
            }
            return await tournaments.ToListAsync();
        }

        public Tournament Update(Tournament tournament)
        {
            var updateResult = _context.Tournaments.Update(tournament);
            return updateResult.Entity;
        }

        public async Task<IEnumerable<TournamentTeam>> SelectTournamentTeams(Guid? tournamentId = null, Guid? teamId = null)
        {
            var tournamentTeams = _context.TournamentTeams.Where(tournamentTeam =>
                    tournamentTeam.TournamentId == (tournamentId ?? tournamentTeam.TournamentId) &&
                    tournamentTeam.TeamId == (teamId ?? tournamentTeam.TeamId)
                );
            return await tournamentTeams.ToListAsync();
        }

        public async Task<TournamentTeam> InsertTeam(TournamentTeam tournamentTeam)
        {
            var insertResult = await _context.TournamentTeams.AddAsync(tournamentTeam);
            return insertResult.Entity;
        }
    }
}
