using Dermayon.Infrastructure.Data.EFRepositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Product.Domain.ProductAggregate.Contracts
{
    public interface IProductCategoryRepository : IEfRepository<ProductCategory>
    {
    }
}
