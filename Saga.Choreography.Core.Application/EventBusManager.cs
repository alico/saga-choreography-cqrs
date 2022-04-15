using MassTransit;
using Saga.Choreography.Core.Domain;

namespace Saga.Choreography.Core.Application
{
    public class EventBusManager<TBus> : IEventBusManager<TBus> where TBus : IBus
    {
        private readonly TBus _bus;

        public EventBusManager(TBus bus)
        {
            _bus = bus;
        }

        public async Task Send<T>(T request, string queueName, CancellationToken cancellationToken = default(CancellationToken)) where T : ICommand
        {
            var sendEndpoint = await _bus.GetSendEndpoint(new Uri($"queue:{queueName}"));
            await sendEndpoint.Send(request, request.GetType(), cancellationToken);
        }

        public async Task Send<T>(T request, string queueName, string routingKey, CancellationToken cancellationToken = default(CancellationToken)) where T : ICommand
        {
            var sendEndpoint = await _bus.GetSendEndpoint(new Uri($"queue:{queueName}"));
            await sendEndpoint.Send(request, request.GetType(), (sendContext) => { sendContext.SetRoutingKey(routingKey); }, cancellationToken);
        }
    }
}