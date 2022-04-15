using MassTransit;
using MediatR;
using Saga.Choreography.Stock.Application.Command;
using Saga.Choreography.Core.Domain.Event;

namespace Saga.Choreography.Stock.Application.Consumer
{
    public class OrderPlacedConsumer : IConsumer<IOrderPlaced>
    {
        private readonly IMediator _mediator;

        public OrderPlacedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<IOrderPlaced> context)
        {
            var order = context.Message;
            var command = new ReserveStockCommand()
            {
                Quantity = order.Quantity,
                CustomerId  = order.CustomerId,
                OrderId = order.OrderId,
                ProductId = order.ProductId
            };

            await _mediator.Send(command, context.CancellationToken);
        }
    }
}
