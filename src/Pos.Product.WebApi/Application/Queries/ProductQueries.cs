using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dermayon.Common.Infrastructure.Data.Contracts;
using Dermayon.Infrastructure.Data.DapperRepositories;
using Pos.Product.Domain.ProductAggregate;

namespace Pos.Customer.WebApi.Application.Queries
{
    public class ProductQueries : IProductQueries
    {
        private readonly IDbConectionFactory _dbConectionFactory;

        public ProductQueries(IDbConectionFactory dbConectionFactory)
        {
            _dbConectionFactory = dbConectionFactory;
        }

        public async Task<MstProduct> GetProduct(Guid id)
        {
            var qry = "SELECT * FROM Product where id = @p1";

            var data = await new DapperRepository<MstProduct>(_dbConectionFactory.GetDbConnection("PRODUCT_READ_CONNECTION"))
                .QueryAsync(qry, new { p1 = id });

            return data.SingleOrDefault();
        }

        public async Task<IEnumerable<MstProduct>> GetProduct(string name)
        {
            var qry = "SELECT * FROM Product where Name like @p1";

            var data = await new DapperRepository<MstProduct>(_dbConectionFactory.GetDbConnection("PRODUCT_READ_CONNECTION"))
                .QueryAsync(qry, new { p1 = $"%{name}%" });

            return data;
        }

        public async Task<IEnumerable<MstProduct>> GetProductByCategory(Guid category)
        {
            var qry = "SELECT * FROM Product where Category = @p1";

            var data = await new DapperRepository<MstProduct>(_dbConectionFactory.GetDbConnection("PRODUCT_READ_CONNECTION"))
                .QueryAsync(qry, new { p1 = category });

            return data;
        }

        public async Task<IEnumerable<MstProduct>> GetProductByPartNumber(string partNumber)
        {
            var qry = "SELECT * FROM Product where PartNumber like @p1";

            var data = await new DapperRepository<MstProduct>(_dbConectionFactory.GetDbConnection("PRODUCT_READ_CONNECTION"))
                .QueryAsync(qry, new { p1 = $"%{partNumber}%" });

            return data;
        }

        public async Task<IEnumerable<MstProduct>> GetProducts()
        {
            var qry = "SELECT * FROM Product";

            var data = await new DapperRepository<MstProduct>(_dbConectionFactory.GetDbConnection("PRODUCT_READ_CONNECTION"))
                .QueryAsync(qry);

            return data;
        }
    }
}
