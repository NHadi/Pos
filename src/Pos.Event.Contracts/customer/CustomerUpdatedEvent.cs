using Dermayon.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Event.Contracts
{
    [Event("CustomerUpdated")]
    public class CustomerUpdatedEvent : IEvent
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
