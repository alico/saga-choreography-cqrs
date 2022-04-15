using MassTransit;
using MassTransit.MultiBus;
using GreenPipes;
using Saga.Choreography.Core.Domain;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

public static class QueueConfigurationExtensions
{
    public static IServiceCollection AddQueueConfiguration(this IServiceCollection services, out IQueueConfiguration queueConfiguration)
    {
        queueConfiguration = new QueueConfiguration()
        {
            Names = new Dictionary<Queue, string>()
        };

        queueConfiguration.Names.Add(Queue.OrderPlaced, "OrderPlaced");
        queueConfiguration.Names.Add(Queue.OrderCompleted, "OrderCompleted");
        queueConfiguration.Names.Add(Queue.StockReserved, "StockReserved");
        queueConfiguration.Names.Add(Queue.StockReleased, "StockReleased");
        queueConfiguration.Names.Add(Queue.PaymentApproved, "PaymentApproved");
        queueConfiguration.Names.Add(Queue.PaymentRejected, "PaymentRejected");

        services.AddSingleton<IQueueConfiguration>(queueConfiguration);

        return services;
    }
}