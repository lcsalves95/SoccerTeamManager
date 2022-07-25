namespace SoccerTeamManager.Domain.ValueObjects
{
    public static class CpfVo
    {
        private static readonly int[] _multiplier = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        public const int CPF_LENGTH = 11;

        public static bool IsValid(string input)
        {
            string cleanInput = input.Replace(".", "").Replace("-", "").Trim();
            if (cleanInput.Length != CPF_LENGTH)
                return false;

            string cpf = cleanInput[..9];
            string digit = CalculateDigit(cpf);
            
            cpf += digit;
            digit += CalculateDigit(cpf);

            return cleanInput.EndsWith(digit);
        }

        private static string CalculateDigit(string docSlice)
        {
            int sum = 0;
            for (int i = 0; i < docSlice.Length; i++)
                sum += int.Parse(docSlice[i].ToString()) * _multiplier[docSlice.Length == 9 ? i + 1 : i];

            int rest = sum % 11;
            rest = rest < 2 ? 0 : 11 - rest;

            return rest.ToString();
        }

    }
}
