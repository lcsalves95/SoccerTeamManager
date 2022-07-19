using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Infra.Base;

namespace SoccerTeamManager.Domain.Entities
{
    public class MatchEvent : Entity
    {
        public Guid MatchId { get; private set; }
        public MatchEventType EventType { get; private set; }
        public DateTime TimeOfOccurrence { get; private set; }
        public Guid? TeamId { get; private set; }

        public Match? Match { get; private set; }

        public MatchEvent(Guid matchId, MatchEventType eventType, Guid? teamId, DateTime timeOfOccurrence)
        {
            MatchId = matchId;
            EventType = eventType;
            TeamId = teamId;
            TimeOfOccurrence = timeOfOccurrence;
        }

        public void UpdateEventType(MatchEventType eventType)
        {
            EventType = eventType;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateTeamId(Guid teamId)
        {
            TeamId = teamId;
            UpdatedAt = DateTime.Now;
        }
    }
}