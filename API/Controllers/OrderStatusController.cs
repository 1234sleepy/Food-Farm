using Domain.UseCases.OrderStatusOperation.Queries.GetAllOderStatuses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace API.Controllers
{
    [ApiController, Route("api/orderstatus")]
    public class OrderStatusController(IMediator mediator, IConfiguration configuration) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly IConfiguration _configuration = configuration;

        [HttpGet()]
        public async Task<ActionResult> GetAllOrderStatuses(CancellationToken cancellationToken)
        {
            var model = new GetAllOrderStatusesQuery();
            var ress = await _mediator.Send(model, cancellationToken);
            return Ok(ress);
        }
    }
}
