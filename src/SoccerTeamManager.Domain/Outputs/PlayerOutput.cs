using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Outputs
{
    public class PlayerOutput : BaseOutput
    {
        public string Name { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string CountryName { get; private set; }
        public string CurrentTeamName { get; private set; }

        public PlayerOutput(Guid id, string name, DateTime dateOfBirth, string countryName, string currentTeamName)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            CountryName = countryName;
            CurrentTeamName = currentTeamName;
        }

        public static PlayerOutput FromEntity(Player player)
        {
            return new PlayerOutput(player.Id, player.Name, player.DateOfBirth, player.Country.Name, player.CurrentTeam?.Name);
        }
    }
}
