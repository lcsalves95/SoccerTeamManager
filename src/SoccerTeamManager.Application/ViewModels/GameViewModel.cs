namespace SoccerTeamManager.Application.ViewModels
{
    public class GameViewModel
    {
        public string Name { get; set; }
       
        /* Times */
        public ICollection<Guid> TeamsId { get; private set; }

        /* Partidas */
        public ICollection<Guid> GamesId { get; private set; }

        public GameViewModel(string name, ICollection<Guid> teamsId, ICollection<Guid> gamesId)
        {
            Name = name;
            TeamsId = teamsId;
            GamesId = gamesId;
        }
    }
}
