using Dermayon.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Event.Contracts
{
    [Event("CustomerCreated")]
    public class CustomerCreatedEvent : IEvent
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
