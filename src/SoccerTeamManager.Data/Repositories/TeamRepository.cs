using Microsoft.EntityFrameworkCore;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Data.Contexts;

namespace SoccerTeamManager.Infra.Data.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Team team)
        {
            _context.Entry(team);
        }

        public async Task<Team> Insert(Team team)
        {
            var insertResult = await _context.AddAsync(team);
            return insertResult.Entity;
        }

        public async Task<IEnumerable<Team>> Select(Guid? id, string? name, States? state)
        {
            var teams = await _context.Teams.Where(team =>
                    team.Id == (id ?? team.Id) &&
                    team.Name == (name ?? team.Name) &&
                    team.Location == (state ?? team.Location)
                ).ToListAsync();
            return teams;
        }

        public Team Update(Team team)
        {
            var updateResult = _context.Teams.Update(team);
            return updateResult.Entity;
        }
    }
}
