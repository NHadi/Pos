using Pos.Product.Domain.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pos.Customer.WebApi.Application.Queries
{
    public interface IProductQueries
    {
        Task<MstProduct> GetProduct(Guid id);
        Task<IEnumerable<MstProduct>> GetProductByCategory(Guid category);
        Task<IEnumerable<MstProduct>> GetProducts();
        Task<IEnumerable<MstProduct>> GetProduct(string name);
        Task<IEnumerable<MstProduct>> GetProductByPartNumber(string partNumber);
    }
}
