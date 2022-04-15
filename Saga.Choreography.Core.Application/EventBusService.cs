using MassTransit;
using Saga.Choreography.Core.Domain;

namespace Saga.Choreography.Core.Application
{
    public class EventBusService<TBus> : IEventBusService<TBus> where TBus : IBus
    {
        private readonly IEventBusManager<TBus> _eventBusManager;
        public EventBusService(IEventBusManager<TBus> eventBusManager)
        {
            _eventBusManager = eventBusManager;
        }

        public async Task<bool> SendCommandAsync<T>(T command, string queueName) where T : ICommand
        {
            try
            {
                if (string.IsNullOrEmpty(queueName))
                    throw new DomainException("queueName can not be empty");

                if (command == null)
                    throw new DomainException("command can not be null");

                await _eventBusManager.Send(command, queueName);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SendCommandAsync<T>(T command, string queueName, string routingKey) where T : ICommand
        {
            try
            {
                if (string.IsNullOrEmpty(queueName))
                    throw new DomainException("queueName can not be empty");

                if (command == null)
                    throw new DomainException("command can not be null");

                await _eventBusManager.Send(command, queueName, routingKey);

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}