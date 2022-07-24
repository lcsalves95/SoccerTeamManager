namespace SoccerTeamManager.Application.ViewModels
{
    public class InsertPlayerViewModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid CountryId { get; set; }
        public string Cpf { get; set; }
        public Guid? TeamId { get; set; }

        public InsertPlayerViewModel(string name, DateTime dateOfBirth, Guid countryId, string cpf, Guid? teamId)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            CountryId = countryId;
            Cpf = cpf;
            TeamId = teamId;
        }
    }
}
