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
            _context.Remove(team);
        }

        public async Task<Team> Insert(Team team)
        {
            var insertResult = await _context.AddAsync(team);
            return insertResult.Entity;
        }

        public async Task<IEnumerable<Team>> Select(Guid? id = null, string? name = null, string? cnpj = null, States? state = null, bool includes = false)
        {
            var teams = _context.Teams.Where(team =>
                    team.Id == (id ?? team.Id) &&
                    team.Name == (name ?? team.Name) &&
                    team.Cnpj == (cnpj ?? team.Cnpj) &&
                    team.Location == (state ?? team.Location));

            if (includes)
                teams.Include(x => x.Players);

            return await teams.ToListAsync();
        }

        public Team Update(Team team)
        {
            var updateResult = _context.Teams.Update(team);
            return updateResult.Entity;
        }
    }
}
