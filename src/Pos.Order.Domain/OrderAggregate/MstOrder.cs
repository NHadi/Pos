using System;
using System.Collections.Generic;
using System.Linq;

namespace Pos.Order.Domain
{
    public partial class MstOrder
    {
        public MstOrder()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public Guid Id { get; set; }
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

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }

        public decimal? GetTotal()
        => OrderDetail.Sum(x => x.GetSubtotal());

        public void AddLineItem(Guid product, int quantity = 1)
        {
            OrderDetail lineItem = GetLineItem(product);
            if (lineItem == null)
            {
                lineItem = new OrderDetail { ProductId = product, Quantity = quantity };
                OrderDetail.Add(lineItem);
            }
            lineItem.Quantity += quantity;
        }

        public OrderDetail GetLineItem(Guid product)
        {
            foreach (var sli in OrderDetail)
                if (sli.ProductId.Equals(product))
                    return sli;
            return null;
        }
    }
}