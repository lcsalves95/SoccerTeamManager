using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoccerTeamManager.Application.Queries;
using SoccerTeamManager.Application.ViewModels;
using SoccerTeamManager.Domain.Commands;

namespace SoccerTeamManager.Api.Controllers
{
    [Route("api/transfers")]
    [ApiController]
    public class TransferController : BaseController
    {
        private readonly IMediator _mediator;

        public TransferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var requestResult = await _mediator.Send(new GetTransferQuery());
            return GetCustomResponseMultipleData(requestResult, HttpContext.Request.Path.Value);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var requestResult = await _mediator.Send(new GetTransferQuery(id: id, singleData: true));
            return GetCustomResponseSingleData(requestResult, null, HttpContext.Request.Path.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(InsertTransferViewModel model)
        {
            var requestResult = await _mediator.Send(new InsertTransferCommand(model.PlayerId, model.OriginTeamId, model.DestinationTeamId, model.Ammount));
            return GetCustomResponseSingleData(requestResult, nameof(GetById), HttpContext.Request.Path.Value);
        }
    }
}
