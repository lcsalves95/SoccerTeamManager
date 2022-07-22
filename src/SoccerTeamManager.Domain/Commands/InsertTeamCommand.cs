using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertTeamCommand : ICommand<RequestResult<Team>>
    {
        public string Name { get; private set; }
        public States Location { get; private set; }

        public InsertTeamCommand(string name, States location)
        {
            Name = name;
            Location = location;
        }
    }
}
