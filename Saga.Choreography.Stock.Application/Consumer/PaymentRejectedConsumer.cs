using MassTransit;
using MediatR;
using Saga.Choreography.Stock.Application.Command;
using Saga.Choreography.Core.Domain.Event;
using System.Diagnostics;

namespace Saga.Choreography.Stock.Application.Consumer
{
    public class PaymentRejectedConsumer : IConsumer<IPaymentRejected>
    {
        private readonly IMediator _mediator;

        public PaymentRejectedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<IPaymentRejected> context)
        {
            var order = context.Message;
            var command = new ReleaseStockCommand()
            {
                OrderId = order.OrderId,
            };

            await _mediator.Send(command, context.CancellationToken);
        }
    }
}
