using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Outputs
{
    public class TeamOutput: BaseOutput
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public States Location { get; set; }
        public IEnumerable<PlayerOutput> Players { get; set; }

        public TeamOutput(string name, string cnpj, States location, IEnumerable<PlayerOutput> players)
        {
            Name = name;
            Cnpj = cnpj;
            Location = location;
            Players = players;
        }

        public static TeamOutput FromEntity(Team team)
        {
            return new TeamOutput(team.Name, team.Cnpj, team.Location, team.Players.Select(p => PlayerOutput.FromEntity(p)));
        }
    }
}
