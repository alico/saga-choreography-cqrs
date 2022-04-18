using MediatR;
using Saga.Choreography.Core.Domain;
using Saga.Choreography.Core.Domain.Event;
using Saga.Choreography.Core.Domain.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saga.Choreography.Order.Application.Command
{
    public class PlaceOrderCommandHandler : IRequestHandler<PlaceOrderCommand, Guid>
    {
        private readonly IEventBusService<IEventBus> _eventBusService;
        private readonly IQueueConfiguration _queueConfiguration;

        public PlaceOrderCommandHandler(IEventBusService<IEventBus> eventBusService, IQueueConfiguration queueConfiguration)
        {
            _eventBusService = eventBusService;
            _queueConfiguration = queueConfiguration;
        }
        public async Task<Guid> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            //..
            //Create an order with pending state
            //..

            var orderPlacedEvent = new OrderPlaced()
            {
                Id = Guid.NewGuid(),
                CustomerId = request.CustomerId,
                OrderId = Guid.NewGuid(),
                ProductId = request.ProductId,
                Quantity = request.Quantity,
            };

            await _eventBusService.SendCommandAsync(orderPlacedEvent, _queueConfiguration.Names[Queue.OrderPlaced], cancellationToken);

            return orderPlacedEvent.OrderId;
        }
    }
}
