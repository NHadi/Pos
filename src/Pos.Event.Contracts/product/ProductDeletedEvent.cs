using Dermayon.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Event.Contracts
{
    [Event("ProductDeleted")]
    public class ProductDeletedEvent : IEvent
    {
        public Guid ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
