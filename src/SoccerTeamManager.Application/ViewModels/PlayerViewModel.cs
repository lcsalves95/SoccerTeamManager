namespace SoccerTeamManager.Application.ViewModels
{
    public class PlayerViewModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid CountryId { get; set; }
        public long CbfCode { get; set; }
        public Guid? TeamId { get; set; }

        public PlayerViewModel(string name, DateTime dateOfBirth, Guid countryId, long cbfCode, Guid? teamId)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            CountryId = countryId;
            CbfCode = cbfCode;
            TeamId = teamId;
        }
    }
}
