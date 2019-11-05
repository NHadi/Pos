using System;

namespace Pos.Event.Contracts
{

    public class OrderDetailDto
    {
        public Guid ProductId { get; set; }        
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }

        public string PartNumber { get; set; }
        public string Name { get; set; }
        public string ProductCategory { get; set; }
    }
}