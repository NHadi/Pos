using Dermayon.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Event.Contracts
{
    [Event("OrderShipped")]
    public class OrderShippedEvent : IEvent
    {
        public Guid OrderId { get; set; }        
    }
}
