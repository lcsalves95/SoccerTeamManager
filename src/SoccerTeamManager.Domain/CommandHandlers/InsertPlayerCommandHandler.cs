using MediatR;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Domain.CommandHandlers
{
    public class InsertPlayerCommandHandler : IRequestHandler<InsertPlayerCommand, RequestResult<Player>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlayerRepository _playerRepository;

        public InsertPlayerCommandHandler(
                    IUnitOfWork unitOfWork, 
                    IPlayerRepository playerRepository)
        {
            _unitOfWork = unitOfWork;
            _playerRepository = playerRepository;
        }

        public async Task<RequestResult<Player>> Handle(InsertPlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player(request.Name, request.DateOfBirth, request.Country, request.TeamId);

            var result = await _playerRepository.Insert(player);

            if (_unitOfWork.Commit())
            {
                return new RequestResult<Player>(System.Net.HttpStatusCode.Created, result, Enumerable.Empty<ErrorModel>());
            }

            return new RequestResult<Player>(System.Net.HttpStatusCode.BadRequest, result, Enumerable.Empty<ErrorModel>());

            //return new RequestResult<Player>(System.Net.HttpStatusCode.Created, new Player("Teste", DateTime.Now.AddYears(-20), "Brazil", Guid.Empty), Enumerable.Empty<ErrorModel>());
        }
    }
}
