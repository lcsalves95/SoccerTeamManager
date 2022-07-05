using FluentValidation;

namespace SoccerTeamManager.Infra.PipelineBehavior
{
    public interface IDeepValidator<T> : IValidator<T>, IEnumerable<IValidationRule>
    {
    }
}
