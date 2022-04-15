namespace Saga.Choreography.Core.Domain
{
    public class RabbitMqSettings
    {
        public string Name { get; set; }
        public string RabbitMqHostUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string VirtualHost { get; set; }
        public int RetryCount { get; set; }
        public int RetryTimeInterval { get; set; }
        public int PrefetchCount { get; set; }
        public int TrackingPeriod { get; set; }
        public int TripThreshold { get; set; }
        public int ActiveThreshold { get; set; }
        public int ResetInterval { get; set; }
    }
}
