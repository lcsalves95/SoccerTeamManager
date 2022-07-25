using Microsoft.EntityFrameworkCore;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Data.Contexts;

namespace SoccerTeamManager.Infra.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> Select(Guid? id = null, string? name = null)
        {
            var countries = await _context.Countries.Where(country =>
                    country.Id == (id ?? country.Id) &&
                    country.Name == (name ?? country.Name)
                ).ToListAsync();
            return countries;
        }
    }
}
