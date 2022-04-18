using MassTransit;

namespace Saga.Choreography.Core.Domain
{
    public interface IEventBusService<TBus> where TBus : IBus
    {
        Task<bool> SendCommandAsync<T>(T command, string queueName, CancellationToken cancellationToken = default(CancellationToken)) where T : ICommand;
        Task<bool> SendCommandAsync<T>(T command, string queueName, string routingKey, CancellationToken cancellationToken = default(CancellationToken)) where T : ICommand;

    }
}