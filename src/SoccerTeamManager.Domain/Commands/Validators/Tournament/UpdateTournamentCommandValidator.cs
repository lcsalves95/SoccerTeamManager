using FluentValidation;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class UpdateTournamentCommandValidator : BaseShallowValidator<UpdateTournamentCommand>, IShallowValidator<UpdateTournamentCommand>
    {
        public UpdateTournamentCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode("InvalidId")
                .WithMessage("O ID deve ser informado");

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
