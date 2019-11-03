using Dermayon.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Product.Domain.Events
{
    [Event("ProductDeleted")]
    public class ProductDeletedEvent : IEvent
    {
        public Guid ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
