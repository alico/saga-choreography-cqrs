using MediatR;
using Microsoft.AspNetCore.Mvc;
using Saga.Choreography.Order.API.Model;
using Saga.Choreography.Order.Application.Command;

namespace Saga.Choreography.Order.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly ILogger<OrderController> _logger;
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator, ILogger<OrderController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var request = new PlaceOrderRequest()
            {
                CustomerId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Quantity = 1,
            };

            var command = new PlaceOrderCommand()
            {
                CustomerId = request.CustomerId,
                Quantity = request.Quantity,
                ProductId = request.ProductId,
            };

            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}