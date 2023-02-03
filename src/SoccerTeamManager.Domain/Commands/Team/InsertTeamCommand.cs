using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertTeamCommand : ICommand<RequestResult<TeamOutput>>
    {
        public string Name { get; private set; }
        public string Cnpj { get; private set; }
        public States Location { get; private set; }

        public InsertTeamCommand(string name, string cnpj, States location)
        {
            Name = name;
            Cnpj = cnpj;
            Location = location;
        }
    }
}
