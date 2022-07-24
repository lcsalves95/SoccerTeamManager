namespace SoccerTeamManager.Application.ViewModels
{
    public class InsertTournamentTeamViewModel
    {
        public Guid TeamId { get; set; }

        public InsertTournamentTeamViewModel(Guid teamId)
        {
            TeamId = teamId;
        }
    }
}
