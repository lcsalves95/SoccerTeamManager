using FluentValidation;
using SoccerTeamManager.Domain.ValueObjects;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class BaseShallowValidator<T> : AbstractValidator<T>
    {
        protected bool BeAValidName(string name)
        {
            var slices = name.Split(' ');

            if (slices.Length < 2)
                return false;

            foreach (var slice in slices)
            {
                var clearTxt = slice.Trim();
                if (string.IsNullOrEmpty(clearTxt) || string.IsNullOrWhiteSpace(clearTxt))
                    return false;
            }

            return true;
        }

        protected bool BeAValidDateOfBirth(DateTime dateOfBirth)
        {
            return dateOfBirth <= DateTime.Now.AddYears(-14) && dateOfBirth >= DateTime.Now.AddYears(-100);
        }

        protected bool BeAValidDate(DateTime date)
        {
            return date >= DateTime.Now;
        }

        protected bool BeAValidCpf(string cpf)
        {
            return CpfVo.IsValid(cpf);
        }

        protected bool BeAValidCnpj(string cnpj)
        {
            return CnpjVo.IsValid(cnpj);
        }
    }
}
