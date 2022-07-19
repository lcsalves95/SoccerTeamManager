using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Entities
{
    public class Country : Entity
    {
        public string Name { get; private set; } = string.Empty;

        public ICollection<Player>? Players { get; private set; }

        public Country()
        {
        }

        public Country(string name)
        {
            Name = name;
        }
    }
}
