using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class UpdateTeamCommand : ICommand<RequestResult<TeamOutput>>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public States Location { get; private set; }

        public UpdateTeamCommand(Guid id, string name, States location)
        {
            Id = id;
            Name = name;
            Location = location;
        }
    }
}
