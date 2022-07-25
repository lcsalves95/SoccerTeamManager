using SoccerTeamManager.Domain.Enums;
using SoccerTeamManager.Infra.Messages;

namespace SoccerTeamManager.Domain.Events
{
    public class CreatedMatchEventEvent : IEvent
    {
        public Guid MatchId { get; private set; }
        public MatchEventType EventType { get; private set; }
        public Guid? TeamId { get; private set; }
        public DateTime TimeOfOccurrence { get; private set; }

        public CreatedMatchEventEvent(Guid matchId, MatchEventType eventType, Guid? teamId, DateTime timeOfOccurrence)
        {
            MatchId = matchId;
            EventType = eventType;
            TeamId = teamId;
            TimeOfOccurrence = timeOfOccurrence;
        }
    }
}
