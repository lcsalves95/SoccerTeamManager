namespace SoccerTeamManager.Infra.IoC.Exceptions
{
    public class ValidationException : Exception
    {
        public Dictionary<string, string[]> ErrorsDictionary { get; private set; }

        public ValidationException(Dictionary<string, string[]> errorsDictionary)
        {
            ErrorsDictionary = errorsDictionary;
        }
    }
}
