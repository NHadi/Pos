using Dermayon.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Product.Domain.Events
{
    [Event("ProductCategoryUpdated")]
    public class ProductCategoryUpdatedEvent : IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
