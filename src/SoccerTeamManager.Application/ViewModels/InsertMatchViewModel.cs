namespace SoccerTeamManager.Application.ViewModels
{
    public class InsertMatchViewModel
    {
        public Guid HomeTeamId { get; set; }
        public Guid VisitorTeamId { get; set; }
        public DateTime MatchDate { get; set; }

        public InsertMatchViewModel(Guid homeTeamId, Guid visitorTeamId, DateTime matchDate)
        {
            HomeTeamId = homeTeamId;
            VisitorTeamId = visitorTeamId;
            MatchDate = matchDate;
        }
    }
}
