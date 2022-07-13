namespace SoccerTeamManager.Application.ViewModels
{
    public class EventReplacementViewModel
    {
        public int Replacement { get; set; }

        public EventReplacementViewModel()
        {

        }

        public EventReplacementViewModel(int replacement)
        {
            Replacement = replacement;
        }
    }
}
