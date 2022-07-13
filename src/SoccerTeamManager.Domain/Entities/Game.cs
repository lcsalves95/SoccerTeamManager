namespace SoccerTeamManager.Domain.Entities
{
    public class Game : Entity
    {
        public ICollection<Event>? Events { get; private set; }

        /* Torneio */
        public Guid TournamentId { get; private set; }
        public Tournament Tournament { get; private set; }

        /* Time 1 */
        public Guid FirstTeamId { get; private set; }
        public Team FirstTeam { get; private set; }

        /* Time 2 */
        public Guid SecondTeamId { get; private set; }
        public Team SecondTeam { get; private set; }

        public Game()
        {
            Tournament = new Tournament();
            FirstTeam = new Team();
            SecondTeam = new Team();
        }

        public Game(
                Guid id,
                Guid tournamentId, 
                Guid firstTeamId,
                Guid secondTeamId)
        {
            Id = id;
            TournamentId = tournamentId;
            FirstTeamId = firstTeamId;
            SecondTeamId = secondTeamId;
        }

        public Game(
               Guid id,
               Tournament tournament,
               Team firstTeam,
               Team secondTeam)
        {
            Id = id;
            Tournament = tournament;
            FirstTeam = firstTeam;
            SecondTeam = secondTeam;
        }

    }
}
