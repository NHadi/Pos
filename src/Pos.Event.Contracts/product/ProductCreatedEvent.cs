using Dermayon.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Event.Contracts
{
    [Event("ProductCreated")]
    public class ProductCreatedEvent : IEvent
    {
        public Guid Category { get; set; }
        public string PartNumber { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
