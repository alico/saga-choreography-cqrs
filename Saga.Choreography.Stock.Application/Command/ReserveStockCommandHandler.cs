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
    public class ReserveStockCommandHandler : IRequestHandler<ReserveStockCommand, Unit>
    {
        private readonly IEventBusService<IEventBus> _eventBusService;
        private readonly IQueueConfiguration _queueConfiguration;


        public ReserveStockCommandHandler(IEventBusService<IEventBus> eventBusService, IQueueConfiguration queueConfiguration)
        {
            _eventBusService = eventBusService;
            _queueConfiguration = queueConfiguration;
        }

        public async Task<Unit> Handle(ReserveStockCommand request, CancellationToken cancellationToken)
        {
            //...
            //Reserve or reject the stock here
            //...

            var stockReservedEvent = new StockReserved()
            {
                Id = Guid.NewGuid(),
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                Quantity = request.Quantity
            };

            await _eventBusService.SendCommandAsync(stockReservedEvent, _queueConfiguration.Names[Queue.StockReserved]);

            return Unit.Value;
        }
    }
}
