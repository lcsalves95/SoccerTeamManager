using FluentValidation;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class InsertTournamentCommandShallowValidator : BaseShallowValidator<InsertTournamentCommand>, IShallowValidator<InsertTournamentCommand>
    {
        public InsertTournamentCommandShallowValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithErrorCode("InvalidName")
                .WithMessage("O nome deve ser informado");

            RuleFor(x => x.Prize)
                .NotEmpty()
                .WithErrorCode("InvalidPrize")
                .WithMessage("A premiação deve ser informada");
        }
    }
}
