using MediatR;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.CommandHandlers
{
    public class InsertEventReplacementCommandHandler : IRequestHandler<InsertEventReplacementCommand, RequestResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventRepository _eventRepository;
        private readonly IGameRepository _gameRepository;

        public InsertEventReplacementCommandHandler(
                    IUnitOfWork unitOfWork,
                    IEventRepository eventRepository,
                    IGameRepository gameRepository)
        {
            _unitOfWork = unitOfWork;
            _eventRepository = eventRepository;
            _gameRepository = gameRepository;
        }

        public async Task<RequestResult<bool>> Handle(InsertEventReplacementCommand request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetById(request.IdGame);

            var eve = new Event(game, request.EventType);
            eve.UpdateReplacement(request.Replacement);
            _eventRepository.Insert(eve);

            if (_unitOfWork.Commit())
            {
                return new RequestResult<bool>(System.Net.HttpStatusCode.Created, true, Enumerable.Empty<ErrorModel>());
            }

            return new RequestResult<bool>(System.Net.HttpStatusCode.BadRequest, false, Enumerable.Empty<ErrorModel>());
        }
    }
}
