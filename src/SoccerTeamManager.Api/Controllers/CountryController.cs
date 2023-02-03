using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoccerTeamManager.Application.Queries;

namespace SoccerTeamManager.Api.Controllers
{
    [Route("api/countries")]
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
    }
}
