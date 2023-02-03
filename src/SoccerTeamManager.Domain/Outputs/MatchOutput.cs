using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Outputs
{
    public class MatchOutput : BaseOutput
    {
        public string Tournament { get; set; }
        public string HomeTeam { get; set; }
        public string VisitorTeam { get; set; }
        public DateTime MatchDate { get; set; }
        public IEnumerable<MatchEvent> Events { get; set; }

        public MatchOutput(Guid id, string tournament, string homeTeam, string visitorTeam, DateTime matchDate, IEnumerable<MatchEvent> events)
        {
            Id = id;
            Tournament = tournament;
            HomeTeam = homeTeam;
            VisitorTeam = visitorTeam;
            MatchDate = matchDate;
            Events = events;
        }

        public static MatchOutput FromEntity(Match match)
        {
            return new MatchOutput(match.Id, match.Tournament.Name, match.HomeTeam.Name, match.VisitorTeam.Name, match.MatchDate, match.MatchEvents);
        }
    }
}
