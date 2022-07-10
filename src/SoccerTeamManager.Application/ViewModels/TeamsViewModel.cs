namespace SoccerTeamManager.Application.ViewModels
{
    public class TeamsViewModel
    {
        public TeamViewModel[] Teams { get; set; }

        public TeamsViewModel()
        {

        }
        public TeamsViewModel(TeamViewModel[] teams)
        {
            Teams = teams;
        }
    }
}
