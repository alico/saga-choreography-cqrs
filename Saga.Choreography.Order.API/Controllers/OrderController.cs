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

        [HttpPut]
        public async Task<IActionResult> Put(PlaceOrderRequest request, CancellationToken cancellationToken)
        {
            if(ModelState.IsValid)
            {
                var command = new PlaceOrderCommand()
                {
                    CustomerId = request.CustomerId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                };

                var result = await _mediator.Send(command, cancellationToken);
                return Ok(result);
            }

            return BadRequest();
        }
    }
}