using Dermayon.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Customer.Domain.Events
{
    [Event("CustomerDeleted")]
    public class CustomerDeletedEvent : IEvent
    {
        public Guid CustomerId { get; set; }        
        public DateTime CreatedAt { get; set; }
    }
}
