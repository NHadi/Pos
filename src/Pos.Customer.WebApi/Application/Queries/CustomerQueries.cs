using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dermayon.Common.Infrastructure.Data.Contracts;
using Dermayon.Infrastructure.Data.DapperRepositories;
using Pos.Customer.Domain.CustomerAggregate;

namespace Pos.Customer.WebApi.Application.Queries
{
    public class CustomerQueries : ICustomerQueries
    {
        private readonly IDbConectionFactory _dbConectionFactory;        

        public CustomerQueries(IDbConectionFactory dbConectionFactory)
        {
            _dbConectionFactory = dbConectionFactory;            
        }


        public async Task<MstCustomer> GetCustomer(Guid id)
        {
            try
            {
                var qry = "SELECT * FROM Customer where Id = @p_id";

                var data = await new DapperRepository<MstCustomer>(_dbConectionFactory.GetDbConnection("CUSTOMER_READ_CONNECTION"))
                    .QueryAsync(qry, new { p_id = id });

                return data.SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<MstCustomer>> GetCustomer(string name)
        {
            try
            {
                var qry = "SELECT * FROM Customer where name = @p_name";

                var data = await new DapperRepository<MstCustomer>(_dbConectionFactory.GetDbConnection("CUSTOMER_READ_CONNECTION"))
                    .QueryAsync(qry, new { p_name = name });

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<MstCustomer>> GetCustomers()
        {
            try
            {
                var qry = "SELECT * FROM Customer";

                var data = await new DapperRepository<MstCustomer>(_dbConectionFactory.GetDbConnection("CUSTOMER_READ_CONNECTION"))
                    .QueryAsync(qry);

                return data;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
