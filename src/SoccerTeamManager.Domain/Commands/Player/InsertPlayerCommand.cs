using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertPlayerCommand : ICommand<RequestResult<PlayerOutput>>
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Guid CountryId { get; private set; }
        public string Cpf { get; set; }
        public Guid? TeamId { get; private set; }

        public InsertPlayerCommand(string name, DateTime dateOfBirth, Guid countryId, string cpf, Guid? teamId)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            CountryId = countryId;
            Cpf = cpf;
            TeamId = teamId;
        }
    }
}
