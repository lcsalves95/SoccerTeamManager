using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Entities
{
    public class Player : Entity
    {
        public string Name { get; private set; } = string.Empty;
        public DateTime DateOfBirth { get; private set; }
        public Guid CountryId { get; private set; }
        public Guid? CurrentTeamId { get; private set; }
        public long FifaCode { get; private set; }

        public Country Country { get; private set; }
        public Team? CurrentTeam { get; private set; }
        public ICollection<Transfer>? Tranfers { get; private set; }

        public Player()
        {

        }

        public Player(string name, DateTime dateOfBirth, Guid countryId, Guid? currentTeamId)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            CountryId = countryId;
            CurrentTeamId = currentTeamId;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Parameter [name] must be valid.", nameof(name));

            Name = name;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateCountry(Guid countryId)
        {
            if (countryId == Guid.Empty)
                throw new ArgumentException("Parameter [countryId] must be valid.", nameof(countryId));

            CountryId = countryId;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateTeam(Guid teamId)
        {
            if (teamId == Guid.Empty)
                throw new ArgumentException("Parameter [teamId] must be valid.", nameof(teamId));

            CurrentTeamId = teamId;
            UpdatedAt = DateTime.Now;
        }
    }
}
