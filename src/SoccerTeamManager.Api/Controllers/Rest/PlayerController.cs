using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Application.ViewModels;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Api.Controllers.Rest
{
    [Route("api/rest/players")]
    [ApiController]
    public class PlayerController : BaseController<Player>
    {
        private readonly IMediator _mediator;

        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var requestResult = await _mediator.Send(new GetPlayerQuery(id: id));
            return GetCustomResponse(requestResult, null, HttpContext.Request.Path.Value);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var requestResult = await _mediator.Send(new GetPlayerQuery(name: name));
            return GetCustomResponse(requestResult, null, HttpContext.Request.Path.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(PlayerViewModel model)
        {
            var command = new InsertPlayerCommand(model.Name, model.DateOfBirth, model.CountryId, model.CbfCode, model.TeamId);
            var requestResult = await _mediator.Send(command);
            return GetCustomResponse(requestResult, nameof(GetById), HttpContext.Request.Path.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, PlayerViewModel model)
        {
            var command = new UpdatePlayerCommand(id, model.Name, model.DateOfBirth, model.CountryId, model.CbfCode, model.TeamId);
            var requestResult = await _mediator.Send(command);
            return GetCustomResponse(requestResult, null, HttpContext.Request.Path.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeletePlayerCommand(id);
            var requestResult = await _mediator.Send(command);
            return GetCustomResponse(requestResult, null, HttpContext.Request.Path.Value);
        }
    }
}
