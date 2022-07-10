using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SoccerTeamManager.Domain.Enums;

namespace SoccerTeamManager.Domain.Entities
{
    public class Team : Entity
    {
        public string Name { get; private set; } = string.Empty;
        [JsonConverter(typeof(StringEnumConverter))]
        public States Location { get; private set; }
        public ICollection<Player>? Players { get; private set; }
        public ICollection<Transfer>? OutTranfers { get; private set; }
        public ICollection<Transfer>? InTranfers { get; private set; }
        public ICollection<Tournament>? Tournaments { get; private set; }
        public ICollection<Game>? FirstGames { get; private set; }
        public ICollection<Game>? SecondGames { get; private set; }

        public Team()
        {

        }

        public Team(string name, States location, DateTime createdAt)
        {
            Name = name;
            Location = location;
            CreatedAt = createdAt;
        }

        public Team(Guid id, string name, States location)
        {
            Id = id;
            Name = name;
            Location = location;
            CreatedAt = DateTime.Now;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Parameter [name] must be valid.", nameof(name));

            Name = name;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateState(States location)
        {
            if (!Enum.IsDefined(typeof(States), location))
                throw new ArgumentException("Parameter [location] must be valid.", nameof(location));

            Location = location;
            UpdatedAt = DateTime.Now;
        }
    }
}
