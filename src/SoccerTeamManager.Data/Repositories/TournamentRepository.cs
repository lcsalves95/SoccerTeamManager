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

        public async Task<IEnumerable<Tournament>> Select(Guid? id = null, string? name = null)
        {
            var tournaments = await _context.Tournaments.Where(tournament =>
                    tournament.Id == (id ?? tournament.Id) &&
                    tournament.Name == (name ?? tournament.Name)
                ).ToListAsync();
            return tournaments;
        }

        public Tournament Update(Tournament tournament)
        {
            var updateResult = _context.Tournaments.Update(tournament);
            return updateResult.Entity;
        }
    }
}
