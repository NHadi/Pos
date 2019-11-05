using Dermayon.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Event.Contracts.order
{
    [Event("OrderCancelled")]
    public class OrderCancelledEvent : IEvent
    {
        public Guid OrderId { get; set; }
    } 
}
