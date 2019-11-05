using Dermayon.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Event.Contracts
{
    [Event("ProductCategoryDeleted")]
    public class ProductCategoryDeletedEvent : IEvent
    {
        public Guid ProductCategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
