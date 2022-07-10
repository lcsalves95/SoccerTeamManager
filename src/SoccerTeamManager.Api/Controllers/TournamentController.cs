using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Application.ViewModels;
using SoccerTeamManager.Domain.Commands;

namespace SoccerTeamManager.Api.Controllers
{
    [Route("api/tournaments")]
    [ApiController]
    public class TournamentController : BaseController
    {
        private readonly IMediator _mediator;

        public TournamentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("many")]
        public async Task<IActionResult> InsertMany(TournamentsViewModel model)
        {
            var commandTournaments = model.Tournaments.Select(t => new InsertTournamentCommand(t.Id.GetValueOrDefault(), t.Name, t.TeamsId));
            var command = new InsertTournamentsCommand(commandTournaments.ToList());
            var requestResult = await _mediator.Send(command);

            return GetCustomResponse(requestResult.GetGenericResponse(), "", HttpContext.Request.Path.Value);
        }
    }
}
