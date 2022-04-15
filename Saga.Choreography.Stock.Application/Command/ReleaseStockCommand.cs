using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saga.Choreography.Stock.Application.Command
{
    public class ReleaseStockCommand : IRequest<Unit>
    {
        public Guid OrderId { get; set; }
    }
}
