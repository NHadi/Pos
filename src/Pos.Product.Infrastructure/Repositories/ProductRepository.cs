using Dermayon.Infrastructure.Data.EFRepositories;
using Pos.Product.Domain.ProductAggregate;
using Pos.Product.Domain.ProductAggregate.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Product.Infrastructure.Repositories
{
    public class ProductRepository : EfRepository<MstProduct>, IProductRepository
    {
        private readonly POSProductContext _context;
        public ProductRepository(POSProductContext context) : base(context)
        {
            _context = context;
        }

    }
}
