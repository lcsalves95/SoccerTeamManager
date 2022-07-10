using MediatR;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.CommandHandlers
{
    public class InsertGamesCommandHandler : IRequestHandler<InsertGamesCommand, RequestResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGameRepository _gameRepository;

        public InsertGamesCommandHandler(
                    IUnitOfWork unitOfWork,
                    IGameRepository gameRepository)
        {
            _unitOfWork = unitOfWork;
            _gameRepository = gameRepository;
        }

        public async Task<RequestResult<bool>> Handle(InsertGamesCommand request, CancellationToken cancellationToken)
        {
            request.Games.ToList().ForEach(t =>
            {
                var game = new Game(t.Id.GetValueOrDefault(), t.TournamentId, t.FirstTeamId, t.SecondTeamId);

                _gameRepository.Insert(game);
            });

            if (_unitOfWork.Commit())
            {
                return new RequestResult<bool>(System.Net.HttpStatusCode.Created, true, Enumerable.Empty<ErrorModel>());
            }

            return new RequestResult<bool>(System.Net.HttpStatusCode.BadRequest, false, Enumerable.Empty<ErrorModel>());
        }
    }
}
