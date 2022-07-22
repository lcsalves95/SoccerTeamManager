using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Entities
{
    public class Player : Entity
    {
        public string Name { get; private set; } = string.Empty;
        public DateTime DateOfBirth { get; private set; }
        public Guid CountryId { get; private set; }
        public Guid? CurrentTeamId { get; private set; }
        public long CbfCode { get; private set; }

        public Country? Country { get; private set; }
        public Team? CurrentTeam { get; private set; }
        public ICollection<Transfer>? Tranfers { get; private set; }

        public Player()
        {
            Country = new Country();
            CurrentTeam = new Team();
            Tranfers = new List<Transfer>();
        }

        public Player(string name, DateTime dateOfBirth, Guid countryId, Guid? currentTeamId, long cbfCode)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            CountryId = countryId;
            CurrentTeamId = currentTeamId;
            CbfCode = cbfCode;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Parameter [name] must be valid.", nameof(name));

            Name = name;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth > DateTime.Now.AddYears(80) || dateOfBirth < DateTime.Now.AddYears(14))
                throw new ArgumentException("Parameter [dateOfBirth] must be valid.", nameof(dateOfBirth));

            DateOfBirth = dateOfBirth;
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

        public void UpdateCbfCode(long code)
        {
            if (code == default)
                throw new ArgumentException("Parameter [cbfCode] must be valid.", nameof(code));

            CbfCode = code;
            UpdatedAt = DateTime.Now;
        }
    }
}
