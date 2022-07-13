namespace SoccerTeamManager.Application.ViewModels
{
    public class EventStartTimeViewModel
    {
        public DateTime StartTime { get; set; }

        public EventStartTimeViewModel()
        {

        }

        public EventStartTimeViewModel(DateTime startTime)
        {
            StartTime = startTime;
        }
    }
}
