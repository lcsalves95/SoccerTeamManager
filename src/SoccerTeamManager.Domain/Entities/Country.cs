using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Entities
{
    public class Country : Entity
    {
        public string Name { get; private set; }

        public ICollection<Player> Players { get; set; }

        public Country()
        {
            Name = string.Empty;
            Players = new List<Player>();
        }

        public Country(string name)
        {
            Name = name;
        }
    }
}
