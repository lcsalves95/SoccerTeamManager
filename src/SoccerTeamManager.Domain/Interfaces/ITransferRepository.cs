using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface ITransferRepository
    {
        Task<Transfer> Insert(Transfer transfer);
        Transfer Update(Transfer transfer);
        Task<IEnumerable<Transfer>> Select(Guid? id = null, Guid? playerId = null, Guid? originalTeam = null, Guid? destinationTeam = null, bool includes = false);
    }
}
