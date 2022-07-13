namespace SoccerTeamManager.Application.ViewModels
{
    public class EventWarningViewModel
    {
        public int Warning { get; set; }

        public EventWarningViewModel()
        {

        }

        public EventWarningViewModel(int warning)
        {
            Warning = warning;
        }
    }
}
