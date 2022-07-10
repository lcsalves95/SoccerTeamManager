namespace SoccerTeamManager.Application.ViewModels
{
    public class TournamentsViewModel
    {
        public TournamentViewModel[] Tournaments { get; set; }

        public TournamentsViewModel()
        {

        }
        public TournamentsViewModel(TournamentViewModel[] tournaments)
        {
            Tournaments = tournaments;
        }
    }
}
