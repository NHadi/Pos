using System;
using System.Collections.Generic;

namespace Pos.Product.Domain.ProductAggregate
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Product = new HashSet<MstProduct>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MstProduct> Product { get; set; }
    }
}