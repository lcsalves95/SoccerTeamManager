using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Outputs
{
    public class TournamentOutput : BaseOutput
    {
        public string Name { get; set; }
        public double Prize { get; set; }
        public IEnumerable<MatchOutput> Matches { get; set; }
        public IEnumerable<TeamOutput> Teams { get; set; }

        public TournamentOutput(string name, double prize, IEnumerable<MatchOutput> matches, IEnumerable<TeamOutput> teams)
        {
            Name = name;
            Prize = prize;
            Matches = matches;
            Teams = teams;
        }

        public static TournamentOutput FromEntity(Tournament tournament)
        {
            return new TournamentOutput(
                tournament.Name,
                tournament.Prize,
                tournament.Matches.Select(m => MatchOutput.FromEntity(m)),
                tournament.TournamentTeams.Select(tt => TeamOutput.FromEntity(tt.Team))
                );
        }
    }
}
