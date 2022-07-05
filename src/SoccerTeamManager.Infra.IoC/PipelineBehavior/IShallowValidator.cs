using FluentValidation;

namespace SoccerTeamManager.Infra.PipelineBehavior
{
    public interface IShallowValidator<T> : IValidator<T>, IEnumerable<IValidationRule>
    {
    }
}
