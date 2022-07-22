using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Messages;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.Commands
{
    public class InsertPlayerCommand : ICommand<RequestResult<Player>>
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Guid CountryId { get; private set; }
        public long CbfCode { get; set; }
        public Guid? TeamId { get; private set; }

        public InsertPlayerCommand(string name, DateTime dateOfBirth, Guid countryId, long cbfCode, Guid? teamId)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            CountryId = countryId;
            CbfCode = cbfCode;
            TeamId = teamId;
        }
    }
}
