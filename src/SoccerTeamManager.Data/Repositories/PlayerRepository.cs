using Microsoft.EntityFrameworkCore;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Data.Contexts;

namespace SoccerTeamManager.Infra.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ApplicationDbContext _context;

        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Player player)
        {
            _context.Players.Remove(player);
        }

        public async Task<Player> Insert(Player player)
        {
            var insertResult = await _context.Players.AddAsync(player);
            return insertResult.Entity;
        }

        public async Task<IEnumerable<Player>> Select(Guid? id = null, string? name = null, Guid? countryId = null, Guid? CurrentTeamId = null, string? cpf = null, bool includes = false)
        {
            var players = _context.Players.Where(player =>
                    player.Id == (id ?? player.Id) &&
                    player.Name == (name ?? player.Name) &&
                    player.CountryId == (countryId ?? player.CountryId) &&
                    player.CurrentTeamId == (CurrentTeamId ?? player.CurrentTeamId) &&
                    player.Cpf == (cpf ?? player.Cpf));

            if (includes)
                players.Include(x => x.Country);

            return await players.ToListAsync();
        }

        public Player Update(Player player)
        {
            var updateResult = _context.Players.Update(player);
            return updateResult.Entity;
        }
    }
}
