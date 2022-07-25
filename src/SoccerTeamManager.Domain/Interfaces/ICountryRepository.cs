using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Domain.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> Select(Guid? id = null, string? name = null);
    }
}