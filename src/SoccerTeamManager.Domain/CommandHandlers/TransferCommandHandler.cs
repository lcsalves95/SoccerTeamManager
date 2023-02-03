using MediatR;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<InsertTransferCommand, RequestResult<TransferOutput>>
    {
        private readonly ITransferRepository _transferRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IUnitOfWork _uow;
        private readonly List<ErrorModel> _errors;

        public TransferCommandHandler(ITransferRepository transferRepository, IPlayerRepository playerRepository, IUnitOfWork uow)
        {
            _transferRepository = transferRepository;
            _playerRepository = playerRepository;
            _uow = uow;
            _errors = new List<ErrorModel>();
        }

        public async Task<RequestResult<TransferOutput>> Handle(InsertTransferCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var transfer = new Transfer(request.PlayerId, request.OriginTeamId, request.DestinationTeamId, request.Ammount);
                transfer = await _transferRepository.Insert(transfer);

                var player = (await _playerRepository.Select(id: request.PlayerId)).First();
                player.UpdateTeam(request.DestinationTeamId);
                player = _playerRepository.Update(player);

                await _uow.Commit();
                return new RequestResult<TransferOutput>(HttpStatusCode.Created, TransferOutput.FromEntity(transfer), Enumerable.Empty<ErrorModel>());
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante o cadastro da tranferencia do jogador:[{request.PlayerId}]"));
                return new RequestResult<TransferOutput>(HttpStatusCode.InternalServerError, default(TransferOutput), _errors);
            }
        }
    }
}
