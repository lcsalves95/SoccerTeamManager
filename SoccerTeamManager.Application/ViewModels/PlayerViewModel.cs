namespace SoccerTeamManager.Application.ViewModels
{
    public class PlayerViewModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public Guid? TeamId { get; set; }

        public PlayerViewModel(string name, DateTime dateOfBirth, string country, Guid? teamId)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Country = country;
            TeamId = teamId;
        }
    }
}
