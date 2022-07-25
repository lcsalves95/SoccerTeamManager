using FluentValidation;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class InsertTransferCommandShallowValidator : BaseShallowValidator<InsertTransferCommand>, IShallowValidator<InsertTransferCommand>
    {
        public InsertTransferCommandShallowValidator()
        {
            RuleFor(x => x.PlayerId)
                .NotEmpty()
                .WithErrorCode("InvalidId")
                .WithMessage("O ID do jogador deve ser informado");

            RuleFor(x => x.OriginTeamId)
                .NotEmpty()
                .WithErrorCode("InvalidId")
                .WithMessage("O ID do time de origem deve ser informado");

            RuleFor(x => x.DestinationTeamId)
                .NotEmpty()
                .WithErrorCode("InvalidId")
                .WithMessage("O ID do time de destino deve ser informado");

        }
    }
}
