using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saga.Choreography.Core.Domain
{
    public enum Queue
    {
        None = 0,
        OrderPlaced = 1,
        StockReserved = 2,
        StockReleased = 3, 
        PaymentApproved = 4,
        PaymentRejected = 5,
        OrderCompleted = 6,
    }
}
