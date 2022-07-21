using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Domain.Entities;

namespace SoccerTeamManager.Api.Controllers.Rest
{
    [Route("api/rest/countries")]
    [ApiController]
    public class CountryController : BaseController<Country>
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
            return GetCustomResponse(requestResult, null, HttpContext.Request.Path.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetCountryQuery(id: id);
            var requestResult = await _mediator.Send(query);
            return GetCustomResponse(requestResult, null, HttpContext.Request.Path.Value);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var query = new GetCountryQuery(name: name);
            var requestResult = await _mediator.Send(query);
            return GetCustomResponse(requestResult, null, HttpContext.Request.Path.Value);
        }

        [HttpGet("{id}/players")]
        public async Task<IActionResult> GetPLayers()
        {
            var query = new GetCountryQuery();
            var requestResult = await _mediator.Send(query);
            return GetCustomResponse(requestResult, null, HttpContext.Request.Path.Value);
        }
    }
}
