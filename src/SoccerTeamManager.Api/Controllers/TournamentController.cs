using Confluent.Kafka;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoccerTeamManager.Api.Services;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Application.ViewModels;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Infra.Responses;
using System.Text.Json;

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

        [HttpPost("{idTournament:guid}/games/{idGame:guid}/events/start-date")]
        public async Task<IActionResult> InsertStartTime(Guid idTournament, Guid idGame, GameStartTimeViewModel model)
        {
            var command = new UpdateGameStartTimeCommand(idGame, model.StartTime);
            
            var messageResult = await ProducerKafkaService.SendMsgStartTimeAsync(command);
            if (messageResult)
            {
                var result = new RequestResult<bool>(System.Net.HttpStatusCode.Created, true, Enumerable.Empty<ErrorModel>());
                
                return GetCustomResponse(result.GetGenericResponse(), "", HttpContext.Request.Path.Value);
            }
            else
            {
                var result = new RequestResult<bool>(System.Net.HttpStatusCode.InternalServerError, false, Enumerable.Empty<ErrorModel>());
                
                return GetCustomResponse(result.GetGenericResponse(), "", HttpContext.Request.Path.Value);
            }
        }

        [HttpPost("{idTournament:guid}/games/{idGame:guid}/events/goal")]
        public async Task<IActionResult> InsertGoal(Guid idTournament, Guid idGame, GameGoalViewModel model)
        {
            var command = new UpdateGameGoalCommand(idGame, model.Goal);

            var messageResult = await ProducerKafkaService.SendMsgGoalAsync(command);
            if (messageResult)
            {
                var result = new RequestResult<bool>(System.Net.HttpStatusCode.Created, true, Enumerable.Empty<ErrorModel>());

                return GetCustomResponse(result.GetGenericResponse(), "", HttpContext.Request.Path.Value);
            }
            else
            {
                var result = new RequestResult<bool>(System.Net.HttpStatusCode.InternalServerError, false, Enumerable.Empty<ErrorModel>());

                return GetCustomResponse(result.GetGenericResponse(), "", HttpContext.Request.Path.Value);
            }
        }

    }
}
