using MediatR;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Domain.Interfaces;
using SoccerTeamManager.Domain.Outputs;
using SoccerTeamManager.Infra.Responses;
using System.Net;

namespace SoccerTeamManager.Domain.CommandHandlers
{
    public class TeamCommandHandler : IRequestHandler<InsertTeamCommand, RequestResult<TeamOutput>>,
                                      IRequestHandler<UpdateTeamCommand, RequestResult<TeamOutput>>,
                                      IRequestHandler<DeleteTeamCommand, RequestResult<TeamOutput>>
    {
        private readonly ITeamRepository _repository;
        private readonly IUnitOfWork _uow;
        private readonly List<ErrorModel> _errors;

        public TeamCommandHandler(ITeamRepository teamRepository, IUnitOfWork uow)
        {
            _repository = teamRepository;
            _uow = uow;
            _errors = new List<ErrorModel>();
        }

        public async Task<RequestResult<TeamOutput>> Handle(InsertTeamCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var team = new Team(request.Name, request.Cnpj, request.Location);
                team = await _repository.Insert(team);
                await _uow.Commit();
                return new RequestResult<TeamOutput>(HttpStatusCode.Created, TeamOutput.FromEntity(team), Enumerable.Empty<ErrorModel>());
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante o cadastro do time {request.Name}"));
                return new RequestResult<TeamOutput>(HttpStatusCode.InternalServerError, default(TeamOutput), _errors);
            }
        }

        public async Task<RequestResult<TeamOutput>> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var team = (await _repository.Select(id: request.Id)).FirstOrDefault();
                if (team == null)
                    return new RequestResult<TeamOutput>(HttpStatusCode.NotFound, default(TeamOutput), _errors);

                team.UpdateName(request.Name);
                team.UpdateLocation(request.Location);

                team = _repository.Update(team);
                await _uow.Commit();
                return new RequestResult<TeamOutput>(HttpStatusCode.OK, TeamOutput.FromEntity(team), Enumerable.Empty<ErrorModel>());
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante a atualização do time {request.Name}"));
                return new RequestResult<TeamOutput>(HttpStatusCode.InternalServerError, default(TeamOutput), _errors);
            }
        }

        public async Task<RequestResult<TeamOutput>> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var team = (await _repository.Select(id: request.Id)).FirstOrDefault();
                if (team == null)
                    return new RequestResult<TeamOutput>(HttpStatusCode.NotFound, default(TeamOutput), _errors);

                _repository.Delete(team);
                await _uow.Commit();
                return new RequestResult<TeamOutput>(HttpStatusCode.NoContent, default(TeamOutput), _errors);
            }
            catch (Exception)
            {
                _errors.Add(new ErrorModel("InternalError", $"Ocorreu um erro inesperado durante a exclusão do time de ID: {request.Id}"));
                return new RequestResult<TeamOutput>(HttpStatusCode.InternalServerError, default(TeamOutput), _errors);
            }
        }
    }
}
