using FluentValidation;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class InsertPlayerCommandValidator : AbstractValidator<InsertPlayerCommand>, IShallowValidator<InsertPlayerCommand>
    {
        public InsertPlayerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome deve ser informado.")
                .WithErrorCode("InvalidName");

            RuleFor(x => x.Name)
                .Must(BeAValidName)
                .WithMessage("O nome deve conter ao menos um sobrenome.")
                .WithErrorCode("InvalidName");

            RuleFor(x => x.Country)
                .NotEmpty()
                .WithMessage("O nome deve ser informado.")
                .WithErrorCode("InvalidCountry");

            //When(x => x.TeamId != null, () =>
            //{
            //    RuleFor(x => x.TeamId)
            //        .Must(BeAValidTeam)
            //        .WithMessage("")
            //        .WithErrorCode("InvalidTeam");
            //});
        }

        private bool BeAValidName(string name)
        {
            var slices = name.Split(' ');

            if (slices.Length < 2)
                return false;

            foreach(var slice in slices)
            {
                var clearTxt = slice.Trim();
                if (string.IsNullOrEmpty(clearTxt) || string.IsNullOrWhiteSpace(clearTxt))
                    return false;
            }

            return true;
        }

        //private bool BeAValidTeam(Guid? teamId)
        //{
        //    return _teamRepository.Select(x => x.Id == teamId).Result != default;
        //}
    }
}
