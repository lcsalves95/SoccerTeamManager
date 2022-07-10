namespace SoccerTeamManager.Application.ViewModels
{
    public class GameStartTimeViewModel
    {
        public DateTime StartTime { get; set; }

        public GameStartTimeViewModel()
        {

        }

        public GameStartTimeViewModel(DateTime sartTime)
        {
            StartTime = sartTime;
        }
    }
}
