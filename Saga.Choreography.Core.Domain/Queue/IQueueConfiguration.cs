using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saga.Choreography.Core.Domain
{
    public interface IQueueConfiguration
    {
        public Dictionary<Queue, string> Names { get; set; }
    }
}
