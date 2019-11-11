using Dermayon.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Event.Contracts
{
    [Event("OrderValidatedEvent")]
    public class OrderValidatedEvent : IEvent
    {
        public OrderValidatedEvent()
        {
            Data = new OrderCreatedEvent();
        }
        public string Action { get; set; }
        public Guid OrderId { get; set; }
        public bool IsValid { get; set; }
        public List<string> Messages { get; set; }
        public OrderCreatedEvent Data { get; set; }
    }
}
