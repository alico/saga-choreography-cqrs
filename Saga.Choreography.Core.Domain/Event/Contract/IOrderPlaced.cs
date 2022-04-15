using Saga.Choreography.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saga.Choreography.Core.Domain.Event
{
    public interface IOrderPlaced : IEvent
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
