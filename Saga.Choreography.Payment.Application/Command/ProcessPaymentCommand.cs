using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saga.Choreography.Payment.Application
{
    public class ProcessPaymentCommand : IRequest<Unit>
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
