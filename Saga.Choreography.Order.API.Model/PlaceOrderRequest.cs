namespace Saga.Choreography.Order.API.Model
{
    public record PlaceOrderRequest
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

    }
}