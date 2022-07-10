namespace SoccerTeamManager.Application.ViewModels
{
    public class GamesViewModel
    {
        public GameViewModel[] Games { get; set; }

        public GamesViewModel()
        {

        }
        public GamesViewModel(GameViewModel[] games)
        {
            Games = games;
        }
    }
}
