using System;
using System.Collections.Generic;

namespace Pos.Product.Domain.ProductAggregate
{
    public partial class MstProduct
    {
        public Guid Id { get; set; }
        public Guid Category { get; set; }
        public string PartNumber { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }

        public virtual ProductCategory CategoryNavigation { get; set; }
    }
}