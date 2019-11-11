using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Order.WebApi.Application.DTO
{
    public class DetailOrderResponse
    {
        public Guid? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public decimal? Amount { get; set; }
        public string Status { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public List<DetailOrderLineItemResponse> OrderDetail { get; set; }
    }
}
