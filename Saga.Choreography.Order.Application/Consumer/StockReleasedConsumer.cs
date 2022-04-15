using MassTransit;
using MediatR;
using Saga.Choreography.Core.Domain;
using Saga.Choreography.Core.Domain.Event;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saga.Choreography.Order.Application.Consumer
{
    public class StockReleasedConsumer : IConsumer<IStockReleased>
    {
        private readonly IMediator _mediator;

        public StockReleasedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<IStockReleased> context)
        {
            var command = context.Message;

            //...
            //Change the order stats as rejected.
            //

            Debug.WriteLine($"Saga.Choreography.Stock.Application.Consumer => PaymentRejected for OrderId: {command.OrderId}");
        }
    }
}
