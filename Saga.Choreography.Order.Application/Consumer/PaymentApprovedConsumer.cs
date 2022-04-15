using MassTransit;
using MediatR;
using Saga.Choreography.Core.Domain;
using Saga.Choreography.Core.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saga.Choreography.Order.Application.Consumer
{
    public class PaymentApprovedConsumer : IConsumer<IPaymentApproved>
    {
        private readonly IMediator _mediator;

        public PaymentApprovedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<IPaymentApproved> context)
        {
            var command = context.Message;

            //...
            //Update the order status as completed
            //

        }
    }
}
