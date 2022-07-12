using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        void Delete(Player player);
        Task<Player> Insert(Player player);
        Task<IEnumerable<Player>> Select(Guid? id = null, string? name = null, Guid? countryId = null, Guid? CurrentTeamId = null, long? cbfCode = null);
        Player Update(Player player);
    }
}
