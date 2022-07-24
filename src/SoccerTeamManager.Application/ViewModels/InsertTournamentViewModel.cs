namespace SoccerTeamManager.Application.ViewModels
{
    public class InsertTournamentViewModel
    {
        public string Name { get; private set; }
        public double Prize { get; private set; }

        public InsertTournamentViewModel(string name, double prize)
        {
            Name = name;
            Prize = prize;
        }
    }
}
