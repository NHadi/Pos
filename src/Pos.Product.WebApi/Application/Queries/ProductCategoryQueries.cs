using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dermayon.Common.Infrastructure.Data.Contracts;
using Dermayon.Infrastructure.Data.DapperRepositories;
using Pos.Product.Domain.ProductAggregate;

namespace Pos.Product.WebApi.Application.Queries
{
    public class ProductCategoryQueries : IProductCategoryQueries
    {
        private readonly IDbConectionFactory _dbConectionFactory;

        public ProductCategoryQueries(IDbConectionFactory dbConectionFactory)
        {
            _dbConectionFactory = dbConectionFactory;
        }
        public async Task<ProductCategory> GetData(Guid id)
        {
            var qry = "SELECT * FROM ProductCategory where id = @p1";

            var data = await new DapperRepository<ProductCategory>(_dbConectionFactory.GetDbConnection("PRODUCT_READ_CONNECTION"))
                .QueryAsync(qry, new { p1 = id });

            return data.SingleOrDefault();
        }

        public async Task<IEnumerable<ProductCategory>> GetData(string name)
        {
            var qry = "SELECT * FROM ProductCategory where Name like @p1";

            var data = await new DapperRepository<ProductCategory>(_dbConectionFactory.GetDbConnection("PRODUCT_READ_CONNECTION"))
                .QueryAsync(qry, new { p1 = $"%{name}%" });

            return data;
        }

        public async Task<IEnumerable<ProductCategory>> GetDatas()
        {
            var qry = "SELECT * FROM ProductCategory";

            var data = await new DapperRepository<ProductCategory>(_dbConectionFactory.GetDbConnection("PRODUCT_READ_CONNECTION"))
                .QueryAsync(qry);

            return data;
        }
    }
}
