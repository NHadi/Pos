using Dermayon.Common.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Event.Contracts
{
    [Event("OrderCreated")]
    public class OrderCreatedEvent : IEvent
    {
        public OrderCreatedEvent()
        {
            OrderItems = new List<OrderDetailDto>();
        }

        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public string Customer { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public decimal? Amount { get; set; }
        public string Status { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public IEnumerable<OrderDetailDto> OrderItems { get; set; }
    }
}
