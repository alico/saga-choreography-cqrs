using MassTransit;
using MediatR;
using Saga.Choreography.Core.Domain.Event;
using Saga.Choreography.Payment.Application;

namespace Saga.Choreography.Payment.Application.Consumer
{
    public class StockReservedConsumer : IConsumer<IStockReserved>
    {
        private readonly IMediator _mediator;

        public StockReservedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<IStockReserved> context)
        {
            var message = context.Message;
            var command = new ProcessPaymentCommand()
            {
                ProductId = message.ProductId,
                OrderId = message.OrderId,
                Quantity = message.Quantity,
            };

            await _mediator.Send(command, context.CancellationToken);
        }
    }
}
