using Microsoft.EntityFrameworkCore;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Data.Contexts;
using System.Linq.Expressions;

namespace SoccerTeamManager.Infra.Data.Repository
{
    public class GameRepository : IGameRepository
    {
        protected readonly ApplicationDbContext _context;
        protected DbSet<Game> _dbSet;

        public GameRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = context.Set<Game>();
        }

        public async Task Delete(Guid entityId)
        {
            _dbSet.Remove(_dbSet.Find(entityId));
        }

        public async Task<Game> Insert(Game entity)
        {
            _dbSet.Add(entity);

            return entity;
        }

        public async Task<IEnumerable<Game>> Select(Expression<Func<Game, bool>> filter)
        {
            return _dbSet.AsNoTracking().Where(filter);
        }

        public async Task<Game> Update(Game entity)
        {
            _dbSet.Update(entity);

            return entity;
        }

        public async Task<Game> GetById(Guid entityId)
        {
            return _dbSet.Find(entityId);
        }
    }
}
