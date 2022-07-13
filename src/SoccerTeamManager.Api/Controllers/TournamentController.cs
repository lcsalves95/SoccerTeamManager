using Confluent.Kafka;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoccerTeamManager.Api.Services;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Application.ViewModels;
using SoccerTeamManager.Domain.Commands;
using SoccerTeamManager.Domain.Enums;
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
        public async Task<IActionResult> InsertStartTime(Guid idTournament, Guid idGame, EventStartTimeViewModel model)
        {
            var command = new InsertEventStartTimeCommand(idGame, model.StartTime, EventTypes.StartTime);
            
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
        public async Task<IActionResult> InsertGoal(Guid idTournament, Guid idGame, EventGoalViewModel model)
        {
            var command = new InsertEventGoalCommand(idGame, model.Goal, EventTypes.Goal);

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

        [HttpPost("{idTournament:guid}/games/{idGame:guid}/events/minute-break")]
        public async Task<IActionResult> InsertGoal(Guid idTournament, Guid idGame, EventMinuteBreakViewModel model)
        {
            var command = new InsertEventMinuteBreakCommand(idGame, model.MinuteBreak, EventTypes.MinuteBreak);

            var messageResult = await ProducerKafkaService.SendMsgMinuteBreakAsync(command);
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

        [HttpPost("{idTournament:guid}/games/{idGame:guid}/events/minute-addition")]
        public async Task<IActionResult> InsertGoal(Guid idTournament, Guid idGame, EventMinuteAdditionViewModel model)
        {
            var command = new InsertEventMinuteAdditionCommand(idGame, model.MinuteAddition, EventTypes.MinuteAddition);

            var messageResult = await ProducerKafkaService.SendMsgMinuteAdditionAsync(command);
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

        [HttpPost("{idTournament:guid}/games/{idGame:guid}/events/replacement")]
        public async Task<IActionResult> InsertReplacement(Guid idTournament, Guid idGame, EventReplacementViewModel model)
        {
            var command = new InsertEventReplacementCommand(idGame, model.Replacement, EventTypes.Replacement);

            var messageResult = await ProducerKafkaService.SendMsgReplacementAsync(command);
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

        [HttpPost("{idTournament:guid}/games/{idGame:guid}/events/warning")]
        public async Task<IActionResult> InsertWarning(Guid idTournament, Guid idGame, EventWarningViewModel model)
        {
            var command = new InsertEventWarningCommand(idGame, model.Warning, EventTypes.Warning);

            var messageResult = await ProducerKafkaService.SendMsgWarningAsync(command);
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

        [HttpPost("{idTournament:guid}/games/{idGame:guid}/events/end-date")]
        public async Task<IActionResult> InsertEndTime(Guid idTournament, Guid idGame, EventEndTimeViewModel model)
        {
            var command = new InsertEventEndTimeCommand(idGame, model.EndTime, EventTypes.EndTime);

            var messageResult = await ProducerKafkaService.SendMsgEndTimeAsync(command);
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
