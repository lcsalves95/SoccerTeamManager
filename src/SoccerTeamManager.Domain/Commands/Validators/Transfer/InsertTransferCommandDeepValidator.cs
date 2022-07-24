using FluentValidation;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.PipelineBehavior;

namespace SoccerTeamManager.Domain.Commands.Validators
{
    public class InsertTransferCommandDeepValidator : BaseDeepValidator<InsertTransferCommand>, IDeepValidator<InsertTransferCommand>
    {
        public InsertTransferCommandDeepValidator(IPlayerRepository playerRepository,
                                                ITeamRepository teamRepository,
                                                ICountryRepository countryRepository,
                                                ITournamentRepository tournamentRepository) : base(playerRepository, teamRepository, countryRepository, tournamentRepository)
        {
            RuleFor(x => x.PlayerId)
                .Must(BeAValidPlayer)
                .WithErrorCode("InvalidPlayer")
                .WithMessage("Jogador não cadastrado");

            RuleFor(x => x.OriginTeamId)
                    .Must(BeAValidTeam)
                    .WithErrorCode("InvalidTeam")
                    .WithMessage("Time da origem não cadastrado");

            RuleFor(x => x.DestinationTeamId)
                .Must(BeAValidTeam)
                .WithErrorCode("InvalidTeam")
                .WithMessage("Time de destino não cadastrado");
        }
    }
}
