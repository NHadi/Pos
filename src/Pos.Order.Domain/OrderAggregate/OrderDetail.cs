using System;
using System.Collections.Generic;

namespace Pos.Order.Domain
{
    public partial class OrderDetail
    {        
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }        
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public virtual MstOrder Order { get; set; }

        public decimal? GetSubtotal()
        {
            return UnitPrice * Quantity;
        }
    }
}