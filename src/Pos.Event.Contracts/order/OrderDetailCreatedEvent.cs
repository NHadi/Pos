using System;

namespace Pos.Event.Contracts
{

    public class OrderDetailDto
    {
        public Guid ProductId { get; set; }        
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }

        public decimal? GetSubtotal()
        {
            return UnitPrice * Quantity;
        }
    }
}