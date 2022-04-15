﻿using Saga.Choreography.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saga.Choreography.Core.Domain.Event
{
    public interface IEvent : ICommand
    {
        public Guid Id { get; set; }
    }
}
