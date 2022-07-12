using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface ITransferRepository
    {
        Task<Transfer> Insert(Transfer transfer);
        Transfer Update(Transfer transfer);
        Task<IEnumerable<Transfer>> Select(Guid? id, Guid? originalTeam, Guid? destinationTeam);
    }
}
