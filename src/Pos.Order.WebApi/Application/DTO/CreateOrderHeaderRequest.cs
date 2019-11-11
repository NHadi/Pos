using Pos.Event.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Order.WebApi.Application.DTO
{
    public class CreateOrderHeaderRequest
    {
        public Guid? CustomerId { get; set; }             
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public List<OrderDetailDto> OrderDetail { get; set; }

        public decimal? GetTotal()
          => OrderDetail.Sum(x => x.GetSubtotal());
    }


}
