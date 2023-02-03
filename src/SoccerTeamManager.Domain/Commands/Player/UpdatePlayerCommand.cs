using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class UpdatePlayerCommand : ICommand<RequestResult<PlayerOutput>>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Guid CountryId { get; private set; }
        public Guid? TeamId { get; private set; }

        public UpdatePlayerCommand(Guid id, string name, DateTime dateOfBirth, Guid countryId, Guid? teamId)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            CountryId = countryId;
            TeamId = teamId;
        }
    }
}
