using FluentValidation;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class UpdateMatchCommandShallowValidator : BaseShallowValidator<UpdateMatchCommand>, IShallowValidator<UpdateMatchCommand>
    {
        public UpdateMatchCommandShallowValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithErrorCode("InvalidId")
                .WithMessage("O ID da partida deve ser informada");

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
