namespace SoccerTeamManager.Domain.Entities
{
    public class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }

        public Entity()
        {
            Id = new Guid();
        }
    }
}
