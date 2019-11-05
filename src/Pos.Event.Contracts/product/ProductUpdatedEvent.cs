using Dermayon.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Event.Contracts
{
    [Event("ProductUpdated")]
    public class ProductUpdatedEvent : IEvent
    {
        public Guid Id { get; set; }
        public Guid Category { get; set; }
        public string PartNumber { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
