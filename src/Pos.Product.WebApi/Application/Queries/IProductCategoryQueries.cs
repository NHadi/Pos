using Pos.Product.Domain.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Product.WebApi.Application.Queries
{
    public interface IProductCategoryQueries
    {
        Task<ProductCategory> GetData(Guid id);
        Task<IEnumerable<ProductCategory>> GetDatas();
        Task<IEnumerable<ProductCategory>> GetData(string name);
    }
}
