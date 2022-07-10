using MediatR;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.CommandHandlers
{
    public class UpdateGameGoalCommandHandler : IRequestHandler<UpdateGameGoalCommand, RequestResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGameRepository _gameRepository;

        public UpdateGameGoalCommandHandler(
                    IUnitOfWork unitOfWork,
                    IGameRepository gameRepository)
        {
            _unitOfWork = unitOfWork;
            _gameRepository = gameRepository;
        }

        public async Task<RequestResult<bool>> Handle(UpdateGameGoalCommand request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetById(request.IdGame);

            game.UpdateGoal(request.Goal);

            if (_unitOfWork.Commit())
            {
                return new RequestResult<bool>(System.Net.HttpStatusCode.Created, true, Enumerable.Empty<ErrorModel>());
            }

            return new RequestResult<bool>(System.Net.HttpStatusCode.BadRequest, false, Enumerable.Empty<ErrorModel>());
        }
    }
}
