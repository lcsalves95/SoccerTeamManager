using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Entities
{
    public class Team : Entity
    {
        public string Name { get; private set; } = string.Empty;
        public string Cnpj { get; private set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public States Location { get; private set; }

        public ICollection<Player>? Players { get; private set; }
        public ICollection<TournamentTeam>? TournamentTeams { get; private set; }

        public Team()
        {
        }

        public Team(string name, string cnpj, States location)
        {
            Name = name;
            Cnpj = cnpj;
            Location = location;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Parameter [name] must be valid.", nameof(name));

            Name = name;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateLocation(States location)
        {
            if (!Enum.IsDefined(typeof(States), location))
                throw new ArgumentException("Parameter [location] must be valid.", nameof(location));

            Location = location;
            UpdatedAt = DateTime.Now;
        }
    }
}
