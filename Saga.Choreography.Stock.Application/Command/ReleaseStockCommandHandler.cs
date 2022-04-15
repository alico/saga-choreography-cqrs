using MediatR;
using Saga.Choreography.Core.Domain;
using Saga.Choreography.Core.Domain.Bus;
using Saga.Choreography.Core.Domain.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saga.Choreography.Stock.Application.Command
{
    public class ReleaseStockCommandHandler : IRequestHandler<ReleaseStockCommand, Unit>
    {
        private readonly IEventBusService<IEventBus> _eventBusService;
        private readonly IQueueConfiguration _queueConfiguration;


        public ReleaseStockCommandHandler(IEventBusService<IEventBus> eventBusService, IQueueConfiguration queueConfiguration)
        {
            _eventBusService = eventBusService;
            _queueConfiguration = queueConfiguration;
        }
        public async Task<Unit> Handle(ReleaseStockCommand request, CancellationToken cancellationToken)
        {
            //...
            //Release the stocks 
            //...

            var stockReleasedEvent = new StockReleased()
            {
                Id = Guid.NewGuid(),
                OrderId = request.OrderId,
            };

            await _eventBusService.SendCommandAsync(stockReleasedEvent, _queueConfiguration.Names[Queue.StockReleased]);

            return Unit.Value;
        }
    }
}
