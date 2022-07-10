using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Application.ViewModels;
using SoccerTeamManager.Domain.Commands;

namespace SoccerTeamManager.Api.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : BaseController
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var player = await _mediator.Send(new GetTeamQuery(id));
            return Ok(player);
        }

        [HttpPost("many")]
        public async Task<IActionResult> InsertMany(TeamsViewModel model)
        {
            var commandTeams = model.Teams.Select(t => new InsertTeamCommand(t.Id.GetValueOrDefault(), t.Name, t.Location));
            var command = new InsertTeamsCommand(commandTeams.ToList());            
            var requestResult = await _mediator.Send(command);
            
            return GetCustomResponse(requestResult.GetGenericResponse(), nameof(Get), HttpContext.Request.Path.Value);
        }
    }
}
