using Microsoft.EntityFrameworkCore;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Data.Contexts;
using System.Linq.Expressions;

namespace SoccerTeamManager.Infra.Data.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        protected readonly ApplicationDbContext _context;
        protected DbSet<Player> _dbSet;

        public PlayerRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<Player>();
        }

        public async Task Delete(Guid entityId)
        {
            _dbSet.Remove(_dbSet.Find(entityId));
        }

        public async Task<Player> Insert(Player entity)
        {
            _dbSet.Add(entity);

            return entity;
        }

        public async Task<IEnumerable<Player>> Select(Expression<Func<Player, bool>> filter)
        {
            return _dbSet.AsNoTracking().Where(filter);
        }

        public async Task<Player> Update(Player entity)
        {
            _dbSet.Update(entity);

            return entity;
        }
    }
}
