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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requestResult = await _mediator.Send(new GetTournamentQuery());
            return GetCustomResponseMultipleData(requestResult, failInstance: HttpContext.Request.Path.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var requestResult = await _mediator.Send(new GetTournamentQuery(id: id, singleData: true));
            return GetCustomResponseSingleData(requestResult, failInstance: HttpContext.Request.Path.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(InsertTournamentViewModel model)
        {
            var command = new InsertTournamentCommand(model.Name, model.Prize);
            var requestResult = await _mediator.Send(command);
            return GetCustomResponseSingleData(requestResult, nameof(GetById), HttpContext.Request.Path.Value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, InsertTournamentViewModel model)
        {
            var command = new UpdateTournamentCommand(id, model.Name, model.Prize);
            var requestResult = await _mediator.Send(command);
            return GetCustomResponseSingleData(requestResult, failInstance: HttpContext.Request.Path.Value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTournamentCommand(id);
            var requestResult = await _mediator.Send(command);
            return GetCustomResponseSingleData(requestResult, failInstance: HttpContext.Request.Path.Value);
        }

        [HttpGet("{id}/teams")]
        public async Task<IActionResult> GetTeams(Guid id)
        {
            return Ok();
        }

        [HttpGet("{tournamentId}/matches")]
        public async Task<IActionResult> GetMatches(Guid tournamentId)
        {
            return Ok();
        }

        [HttpGet("{tournamentId}/matches/{matchId}")]
        public async Task<IActionResult> GetMatchById(Guid tournamentId, Guid matchId)
        {
            return Ok();
        }

        [HttpPost("{tournamentId}/matches")]
        public async Task<IActionResult> InsertMatch(Guid tournamentId, InsertMatchViewModel model)
        {
            return Ok();
        }

        [HttpPut("{tournamentId}/matches/{matchId}")]
        public async Task<IActionResult> UpdateMatch(Guid tournamentId, Guid matchId, InsertMatchViewModel model)
        {
            return Ok();
        }

        [HttpDelete("{tournamentId}/matches/{matchId}")]
        public async Task<IActionResult> DeleteMatch(Guid tournamentId, Guid matchId)
        {
            return Ok();
        }

        [HttpGet("{tournamentId}/matches/{matchId}/events")]
        public async Task<IActionResult> GetMatchEvents(Guid tournamentId, Guid matchId)
        {
            return Ok();
        }

        [HttpGet("{tournamentId}/matches/{matchId}/events/{id}")]
        public async Task<IActionResult> GetMatchEventById(Guid tournamentId, Guid matchId, Guid id)
        {
            return Ok();
        }

        [HttpPost("{tournamentId}/matches/{matchId}/events")]
        public async Task<IActionResult> InsertMatchEvents(Guid tournamentId, Guid matchId, InsertMatchEventViewModel model)
        {
            return Ok();
        }
    }
}
