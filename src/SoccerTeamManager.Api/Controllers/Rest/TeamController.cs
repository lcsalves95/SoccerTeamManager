using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Application.ViewModels;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Api.Controllers.Rest
{
    [Route("api/rest/teams")]
    [ApiController]
    public class TeamController : BaseController
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requestResult = await _mediator.Send(new GetTeamQuery());
            return GetCustomResponseMultipleData(requestResult, failInstance: HttpContext.Request.Path.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var requestResult = await _mediator.Send(new GetTeamQuery(id: id, singleData: true));
            return GetCustomResponseSingleData(requestResult, failInstance: HttpContext.Request.Path.Value);
        }

        [HttpGet("{id}/players")]
        public async Task<IActionResult> GetPlayers(Guid id)
        {
            var requestResult = await _mediator.Send(new GetTeamQuery(id: id));
            var countryData = (Team?)requestResult.Data;
            var playersResult = new RequestResult<Player>(requestResult.StatusCode, countryData?.Players, requestResult.Errors);
            return GetCustomResponseMultipleData(requestResult, HttpContext.Request.Path.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(InsertTeamViewModel model)
        {
            var command = new InsertTeamCommand(model.Name, model.Cnpj, model.Location);
            var requestResult = await _mediator.Send(command);
            return GetCustomResponseSingleData(requestResult, nameof(GetById), HttpContext.Request.Path.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, InsertTeamViewModel model)
        {
            var command = new UpdateTeamCommand(id, model.Name, model.Location);
            var requestResult = await _mediator.Send(command);
            return GetCustomResponseSingleData(requestResult, failInstance: HttpContext.Request.Path.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTeamCommand(id);
            var requestResult = await _mediator.Send(command);
            return GetCustomResponseSingleData(requestResult, failInstance: HttpContext.Request.Path.Value);
        }
    }
}
