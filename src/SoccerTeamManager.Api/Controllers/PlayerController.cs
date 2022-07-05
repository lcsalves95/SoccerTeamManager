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
        public async Task<IActionResult> Get(Guid id)
        {
            var player = await _mediator.Send(new GetPlayerQuery(id));
            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(PlayerViewModel model)
        {
            var command = new InsertPlayerCommand(model.Name, model.DateOfBirth, model.Country, model.TeamId);
            var requestResult = await _mediator.Send(command);
            return GetCustomResponse(requestResult.GetGenericResponse(), nameof(Get), HttpContext.Request.Path.Value);
        }
    }
}
