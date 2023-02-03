using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Application.ViewModels;
using SoccerTeamManager.Domain.Commands;

namespace SoccerTeamManager.Api.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : BaseController
    {
        private readonly IMediator _mediator;

        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requestResult = await _mediator.Send(new GetPlayerQuery());
            return GetCustomResponseMultipleData(requestResult, failInstance: HttpContext.Request.Path.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var requestResult = await _mediator.Send(new GetPlayerQuery(id: id, singleData: true));
            return GetCustomResponseSingleData(requestResult, failInstance: HttpContext.Request.Path.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(InsertPlayerViewModel model)
        {
            var command = new InsertPlayerCommand(model.Name, model.DateOfBirth, model.CountryId, model.Cpf, model.TeamId);
            var requestResult = await _mediator.Send(command);
            return GetCustomResponseSingleData(requestResult, nameof(GetById), HttpContext.Request.Path.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, InsertPlayerViewModel model)
        {
            var command = new UpdatePlayerCommand(id, model.Name, model.DateOfBirth, model.CountryId, model.TeamId);
            var requestResult = await _mediator.Send(command);
            return GetCustomResponseSingleData(requestResult, failInstance: HttpContext.Request.Path.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePlayerCommand(id);
            var requestResult = await _mediator.Send(command);
            return GetCustomResponseSingleData(requestResult, failInstance: HttpContext.Request.Path.Value);
        }
    }
}
