using MediatR;
using Saga.Choreography.Core.Domain;
using Saga.Choreography.Core.Domain.Bus;
using Saga.Choreography.Core.Domain.Event;

namespace Saga.Choreography.Payment.Application
{
    public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommand, Unit>
    {
        private readonly IEventBusService<IEventBus> _eventBusService;
        private readonly IQueueConfiguration _queueConfiguration;

        public ProcessPaymentCommandHandler(IEventBusService<IEventBus> eventBusService, IQueueConfiguration queueConfiguration)
        {
            _eventBusService = eventBusService;
            _queueConfiguration = queueConfiguration;
        }
        public async Task<Unit> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
        {
            //...
            //Charge the amount here
            //...

            //Let's randomize the payment.
            var rnd = new Random();
            if (rnd.Next(1, 1000) % 2 == 0)
            {
                var paymentApproved = new PaymentApproved()
                {
                    Id = Guid.NewGuid(),
                    OrderId = request.OrderId
                };

                await _eventBusService.SendCommandAsync(paymentApproved, _queueConfiguration.Names[Queue.PaymentApproved]);
            }
            else
            {
                var paymentRejected = new PaymentRejected()
                {
                    Id = Guid.NewGuid(),
                    OrderId = request.OrderId
                };
                await _eventBusService.SendCommandAsync(paymentRejected, _queueConfiguration.Names[Queue.PaymentRejected]);
            }

            return Unit.Value;
        }
    }
}
