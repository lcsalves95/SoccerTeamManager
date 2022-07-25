using SoccerTeamManager.Domain.Enums;

namespace SoccerTeamManager.Application.ViewModels
{
    public class InsertMatchEventViewModel
    {
        public MatchEventType Type { get; set; }
        public DateTime TimeOfOccurrence { get; set; }
        public Guid? TeamId { get; set; }

        public InsertMatchEventViewModel(MatchEventType type, DateTime timeOfOccurrence, Guid? teamId = null)
        {
            Type = type;
            TimeOfOccurrence = timeOfOccurrence;
            TeamId = teamId;
        }
    }
}
