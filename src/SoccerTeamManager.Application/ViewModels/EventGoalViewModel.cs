namespace SoccerTeamManager.Application.ViewModels
{
    public class EventGoalViewModel
    {
        public int Goal { get; set; }

        public EventGoalViewModel()
        {

        }

        public EventGoalViewModel(int goal)
        {
            Goal = goal;
        }
    }
}
