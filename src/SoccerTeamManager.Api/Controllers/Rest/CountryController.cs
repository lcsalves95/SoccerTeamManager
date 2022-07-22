using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Entities;
using SoccerTeamManager.Infra.Responses;

namespace SoccerTeamManager.Api.Controllers.Rest
{
    [Route("api/rest/countries")]
    [ApiController]
    public class CountryController : BaseController
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetCountryQuery();
            var requestResult = await _mediator.Send(query);
            return GetCustomResponseMultipleData(requestResult, HttpContext.Request.Path.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCountryQuery(id: id, singleData: true);
            var requestResult = await _mediator.Send(query);
            return GetCustomResponseSingleData(requestResult, HttpContext.Request.Path.Value);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var query = new GetCountryQuery(name: name);
            var requestResult = await _mediator.Send(query);
            return GetCustomResponseMultipleData(requestResult, HttpContext.Request.Path.Value);
        }

        [HttpGet("{id}/players")]
        public async Task<IActionResult> GetPlayers(Guid id)
        {
            var query = new GetCountryQuery(id: id, singleData: true);
            var requestResult = await _mediator.Send(query);
            var countryData = (Country?)requestResult.Data;
            var playersResult = new RequestResult<Player>(requestResult.StatusCode, countryData?.Players, requestResult.Errors);
            return GetCustomResponseMultipleData(playersResult, HttpContext.Request.Path.Value);
        }
    }
}
