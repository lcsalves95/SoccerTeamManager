using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Application.ViewModels;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Api.Controllers.Rest
{
    [Route("api/rest/tournaments")]
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
            var requestResult = await _mediator.Send(new GetTournamentTeamsQuery(id));
            return GetCustomResponseMultipleData(requestResult, HttpContext.Request.Path.Value);
        }

        [HttpPost("{tournamentId}/teams")]
        public async Task<IActionResult> InsertTeams(Guid tournamentId, InsertTournamentTeamViewModel model)
        {
            var requestResult = await _mediator.Send(new InsertTournamentTeamCommand(tournamentId, model.TeamId));
            return GetCustomResponseSingleData(requestResult, HttpContext.Request.Path.Value);
        }

        [HttpDelete("{tournamentId}/teams/{teamId}")]
        public async Task<IActionResult> DeleteTeams(Guid tournamentId, Guid teamId)
        {
            var requestResult = await _mediator.Send(new DeleteTournamentTeamCommand(tournamentId, teamId));
            return GetCustomResponseSingleData(requestResult, HttpContext.Request.Path.Value);
        }

        [HttpGet("{tournamentId}/matches")]
        public async Task<IActionResult> GetMatches(Guid tournamentId)
        {
            var requestResult = await _mediator.Send(new GetMatchQuery(tournamentId: tournamentId));
            return GetCustomResponseMultipleData(requestResult, HttpContext.Request.Path.Value);
        }

        [HttpGet("{tournamentId}/matches/{matchId}")]
        public async Task<IActionResult> GetMatchById(Guid tournamentId, Guid matchId)
        {
            var requestResult = await _mediator.Send(new GetMatchQuery(tournamentId, matchId, true));
            return GetCustomResponseSingleData(requestResult, HttpContext.Request.Path.Value);
        }

        [HttpPost("{tournamentId}/matches")]
        public async Task<IActionResult> InsertMatch(Guid tournamentId, InsertMatchViewModel model)
        {
            var command = new InsertMatchCommand(tournamentId, model.HomeTeamId, model.VisitorTeamId, model.MatchDate);
            var requestResult = await _mediator.Send(command);
            return GetCustomResponseSingleData(requestResult, nameof(GetById), HttpContext.Request.Path.Value);
        }

        [HttpPut("{tournamentId}/matches/{matchId}")]
        public async Task<IActionResult> UpdateMatch(Guid tournamentId, Guid matchId, InsertMatchViewModel model)
        {
            var command = new UpdateMatchCommand(matchId, tournamentId, model.HomeTeamId, model.VisitorTeamId, model.MatchDate);
            var requestResult = await _mediator.Send(command);
            return GetCustomResponseSingleData(requestResult, nameof(GetById), HttpContext.Request.Path.Value);
        }

        [HttpDelete("{tournamentId}/matches/{matchId}")]
        public async Task<IActionResult> DeleteMatch(Guid tournamentId, Guid matchId)
        {
            var command = new DeleteMatchCommand(matchId, tournamentId);
            var requestResult = await _mediator.Send(command);
            return GetCustomResponseSingleData(requestResult, nameof(GetById), HttpContext.Request.Path.Value);
        }

        [HttpGet("{tournamentId}/matches/{matchId}/events")]
        public async Task<IActionResult> GetMatchEvents(Guid tournamentId, Guid matchId)
        {
            var requestResult = await _mediator.Send(new GetMatchEventsQuery(tournamentId, matchId));
            return GetCustomResponseMultipleData(requestResult, HttpContext.Request.Path.Value);
        }

        [HttpPost("{tournamentId}/matches/{matchId}/events")]
        public async Task<IActionResult> InsertMatchEvents(Guid tournamentId, Guid matchId, InsertMatchEventViewModel model)
        {
            var requestResult = await _mediator.Send(new InsertMatchEventCommand(tournamentId, matchId, model.TeamId, model.Type, model.TimeOfOccurrence));
            return GetCustomResponseSingleData(requestResult, null, HttpContext.Request.Path.Value);
        }
    }
}
