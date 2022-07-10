using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Application.ViewModels;
using SoccerTeamManager.Domain.Commands;

namespace SoccerTeamManager.Api.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GameController : BaseController
    {
        private readonly IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("many")]
        public async Task<IActionResult> InsertMany(GamesViewModel model)
        {
            var commandGames = model.Games.Select(t => new InsertGameCommand(t.Id.GetValueOrDefault(), t.TournamentId, t.FirstTeamId, t.SecondTeamId));
            var command = new InsertGamesCommand(commandGames.ToList());            
            var requestResult = await _mediator.Send(command);
            
            return GetCustomResponse(requestResult.GetGenericResponse(), "", HttpContext.Request.Path.Value);
        }
    }
}
