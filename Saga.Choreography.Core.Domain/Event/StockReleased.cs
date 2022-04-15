﻿using Saga.Choreography.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saga.Choreography.Core.Domain.Event
{
    public class StockReleased : IStockReleased
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
    }
}
