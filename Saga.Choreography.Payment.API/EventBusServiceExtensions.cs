using MassTransit;
using MassTransit.MultiBus;
using GreenPipes;
using Newtonsoft.Json;
using Saga.Choreography.Core;
using MediatR;
using Saga.Choreography.Core.Domain;
using Saga.Choreography.Core.Application;
using System.Reflection;
using Saga.Choreography.Payment.Application;
using Saga.Choreography.Payment.Application.Consumer;
using Saga.Choreography.Core.Domain.Bus;

public static class EventBusServiceExtensions
{
    public static IServiceCollection AddEventBus(this IServiceCollection services, IConfigurationRoot configuration)
    {
        services.AddQueueConfiguration(out IQueueConfiguration queueConfiguration);

        var rabbitMQConfig = new List<RabbitMqSettings>();
        var rabbitMqConfigurations = configuration.GetSection("RabbitMqSettings").Get<List<RabbitMqSettings>>();

        var config = rabbitMqConfigurations.FirstOrDefault(y => y.Name == "MainHost");
        if (config == null) throw new ArgumentNullException("MainHost section hasn't been found in the appsettings.");

        services.AddMassTransit<IEventBus>(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                var mediator = context.GetRequiredService<IMediator>();
                cfg.Host(config.RabbitMqHostUrl, config.VirtualHost, h =>
                {
                    h.Username(config.Username);
                    h.Password(config.Password);
                });

                cfg.UseJsonSerializer();
                cfg.UseRetry(c => c.Interval(config.RetryCount, config.ResetInterval));
                cfg.ConfigureEndpoints(context);

                cfg.ReceiveEndpoint(queueConfiguration.Names[Queue.StockReserved], e =>
                {
                    e.PrefetchCount = 1;
                    e.UseMessageRetry(x => x.Interval(config.RetryCount, config.ResetInterval));
                    e.UseCircuitBreaker(cb =>
                    {
                        cb.TrackingPeriod = TimeSpan.FromMinutes(config.TrackingPeriod);
                        cb.TripThreshold = config.TripThreshold;
                        cb.ActiveThreshold = config.ActiveThreshold;
                        cb.ResetInterval = TimeSpan.FromMinutes(config.ResetInterval);
                    });

                    e.Consumer(() => new StockReservedConsumer(mediator));
                });
            });
        });

        services.AddSingleton(rabbitMQConfig);
        services.AddTransient(typeof(IEventBusService<>), typeof(EventBusService<>));
        services.AddTransient(typeof(IEventBusManager<>), typeof(EventBusManager<>));
        services.AddMassTransitHostedService();
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMediatR(typeof(ProcessPaymentCommand).GetTypeInfo().Assembly);


        return services;

    }
}