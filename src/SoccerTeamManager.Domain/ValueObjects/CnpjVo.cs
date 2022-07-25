namespace SoccerTeamManager.Domain.ValueObjects
{
    public static class CnpjVo
    {
        private static readonly int[] _multiplier = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public const int CNPJ_LENGTH = 14;

        public static bool IsValid(string input)
        {
            string cleanInput = input.Replace(".", "").Replace("-", "").Trim();
            if (cleanInput.Length != CNPJ_LENGTH)
                return false;

            string cnpj = cleanInput[..12];
            string digit = CalculateDigit(cnpj);

            cnpj += digit;
            digit += CalculateDigit(cnpj);

            return cleanInput.EndsWith(digit);
        }

        private static string CalculateDigit(string docSlice)
        {
            int sum = 0;
            for (int i = 0; i < docSlice.Length; i++)
                sum += int.Parse(docSlice[i].ToString()) * _multiplier[docSlice.Length == 12 ? i + 1 : i];

            int rest = sum % 11;
            rest = rest < 2 ? 0 : 11 - rest;

            return rest.ToString();
        }
    }
}
