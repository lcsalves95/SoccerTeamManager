using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTeamManager.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            var result = _context.SaveChanges();

            return result > 0;
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
        {
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
