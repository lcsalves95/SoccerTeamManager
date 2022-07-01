using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.IoC.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertPlayerCommand : ICommand<Player>
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Country { get; private set; }
        public Guid? TeamId { get; private set; }

        public InsertPlayerCommand(string name, DateTime dateOfBirth, string country, Guid? teamId)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Country = country;
            TeamId = teamId;
        }
    }
}
