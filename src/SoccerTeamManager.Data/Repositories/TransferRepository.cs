using Microsoft.EntityFrameworkCore;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Data.Contexts;

namespace SoccerTeamManager.Infra.Data.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly ApplicationDbContext _context;

        public TransferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transfer> Insert(Transfer transfer)
        {
            var insertResult = await _context.Transfers.AddAsync(transfer);
            return insertResult.Entity;
        }

        public async Task<IEnumerable<Transfer>> Select(Guid? id, Guid? originalTeam, Guid? destinationTeam, bool includes = false)
        {
            var transfers = _context.Transfers.Where(tranfer =>
                    tranfer.Id == (id ?? tranfer.Id) &&
                    tranfer.OriginTeamId == (originalTeam ?? tranfer.OriginTeamId) &&
                    tranfer.DestinationTeamId == (destinationTeam ?? tranfer.DestinationTeamId));

            if (includes)
            {
                transfers.Include(x => x.OriginTeam);
                transfers.Include(x => x.DestinationTeam);
                transfers.Include(x => x.Player);
            }

            return await transfers.ToListAsync();
        }

        public Transfer Update(Transfer transfer)
        {
            var updateResult = _context.Transfers.Update(transfer);
            return updateResult.Entity;
        }
    }
}
