using MassTransit;

namespace Saga.Choreography.Core.Domain
{
    public interface IEventBusService<TBus> where TBus : IBus
    {
        Task<bool> SendCommandAsync<T>(T command, string queueName) where T : ICommand;
        Task<bool> SendCommandAsync<T>(T command, string queueName, string routingKey) where T : ICommand;

    }
}