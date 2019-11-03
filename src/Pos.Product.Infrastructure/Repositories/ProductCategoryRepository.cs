using Dermayon.Infrastructure.Data.EFRepositories;
using Pos.Product.Domain.ProductAggregate;
using Pos.Product.Domain.ProductAggregate.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Product.Infrastructure.Repositories
{
    public class ProductCategoryRepository : EfRepository<ProductCategory>, IProductCategoryRepository
    {
        private readonly POSProductContext _context;
        public ProductCategoryRepository(POSProductContext context) : base(context)
        {
            _context = context;
        }

    }
}
