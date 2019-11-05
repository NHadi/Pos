using Dermayon.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Event.Contracts
{
    [Event("ProductCategoryCreated")]
    public class ProductCategoryCreatedEvent : IEvent
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
