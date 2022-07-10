namespace SoccerTeamManager.Application.ViewModels
{
    public class GameGoalViewModel
    {
        public int Goal { get; set; }

        public GameGoalViewModel()
        {

        }

        public GameGoalViewModel(int goal)
        {
            Goal = goal;
        }
    }
}
