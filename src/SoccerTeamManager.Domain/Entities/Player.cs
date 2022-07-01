namespace SoccerTeamManager.Domain.Entities
{
    public class Player : Entity
    {
        public string Name { get; private set; } = string.Empty;
        public DateTime DateOfBirth { get; private set; }
        public string Country { get; private set; } = string.Empty;
        public Guid? CurrentTeamId { get; private set; }

        public Team? CurrentTeam { get; private set; }
        public ICollection<Transfer>? Tranfers { get; private set; }

        public Player()
        {

        }

        public Player(string name, DateTime dateOfBirth, string country, Guid? currentTeamId)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Country = country;
            CurrentTeamId = currentTeamId;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Parameter [name] must be valid.", nameof(name));

            Name = name;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateCountry(string country)
        {
            if (string.IsNullOrEmpty(country) || string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Parameter [country] must be valid.", nameof(country));

            Country = country;
            UpdatedAt = DateTime.Now;
        }

        public void SetCurrentTeam(Guid teamId) => CurrentTeamId = teamId;
    }
}
