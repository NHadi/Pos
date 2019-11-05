using Dermayon.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Event.Contracts
{
    [Event("OrderValidatedEvent")]
    public class OrderValidatedEvent : IEvent
    {
        public Guid OrderId { get; set; }
        public bool IsValid { get; set; }
        public List<string> Messages { get; set; }
    }
}
