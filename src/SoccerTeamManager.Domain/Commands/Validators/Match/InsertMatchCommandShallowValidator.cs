using FluentValidation;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class InsertMatchCommandShallowValidator : BaseShallowValidator<InsertMatchCommand>, IShallowValidator<InsertMatchCommand>
    {
        public InsertMatchCommandShallowValidator()
        {
            RuleFor(x => x.TournamentId)
                .NotEmpty()
                .WithErrorCode("InvalidId")
                .WithMessage("O ID do torneio deve ser informado");

            RuleFor(x => x.HomeTeamId)
                .NotEmpty()
                .WithErrorCode("InvalidId")
                .WithMessage("O ID do time da casa deve ser informado");

            RuleFor(x => x.VisitorTeamId)
                .NotEmpty()
                .WithErrorCode("InvalidId")
                .WithMessage("O ID do time visitante deve ser informado");

            RuleFor(x => x.MatchDate)
                .NotEmpty()
                .WithErrorCode("InvalidDate")
                .WithMessage("A data da partida deve ser informada");

            RuleFor(x => x.MatchDate)
                .Must(BeAValidDate)
                .WithErrorCode("InvalidDate")
                .WithMessage("A data da partida deve maior que a data atual");
        }
    }
}
