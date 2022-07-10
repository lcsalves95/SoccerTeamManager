namespace SoccerTeamManager.Application.ViewModels
{
    public class GameViewModel
    {
        public Guid? Id { get; set; }

        /* Torneio */
        public Guid TournamentId { get; set; }

        /* Time 1 */
        public Guid FirstTeamId { get; set; }

        /* Time 2 */
        public Guid SecondTeamId { get; set; }

        public GameViewModel()
        {

        }

        public GameViewModel(Guid id, Guid tournamentId, Guid firstTeamId, Guid secondTeamId)
        {
            Id = id;
            TournamentId = tournamentId;
            FirstTeamId = firstTeamId;
            SecondTeamId = secondTeamId;
        }
    }
}
