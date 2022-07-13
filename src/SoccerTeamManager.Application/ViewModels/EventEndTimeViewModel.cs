namespace SoccerTeamManager.Application.ViewModels
{
    public class EventEndTimeViewModel
    {
        public DateTime EndTime { get; set; }

        public EventEndTimeViewModel()
        {

        }

        public EventEndTimeViewModel(DateTime endTime)
        {
            EndTime = endTime;
        }
    }
}
