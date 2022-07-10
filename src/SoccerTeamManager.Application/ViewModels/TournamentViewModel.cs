namespace SoccerTeamManager.Application.ViewModels
{
    public class TournamentViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
       
        /* Times */
        public Guid[] TeamsId { get; set; }

        public TournamentViewModel()
        {

        }

        public TournamentViewModel(string name, Guid[] teamsId)
        {
            Name = name;
            TeamsId = teamsId;
        }

        public TournamentViewModel(Guid id, string name, Guid[] teamsId)
        {
            Id = id;
            Name = name;
            TeamsId = teamsId;
        }
    }
}
