namespace SoccerTeamManager.Domain.Entities
{
    public class Tournament : Entity
    {
        public string Name { get; private set; } = string.Empty;

        /* Times */
        public ICollection<Team>? Teams { get; private set; }

        /* Partidas */
        public ICollection<Game>? Games { get; private set; }

        public Tournament()
        {

        }

        public Tournament(string name)
        {
            Name = name;
        }

        public Tournament(Guid id, string name, ICollection<Team> teams)
        {
            Id = id;
            Name = name;
            Teams = teams;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Parameter [name] must be valid.", nameof(name));

            Name = name;
            UpdatedAt = DateTime.Now;
        }

    }
}
