using Pos.Customer.Domain.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Customer.WebApi.Application.Queries
{
    public interface ICustomerQueries
    {
        Task<MstCustomer> GetCustomer(Guid id);
        Task<IEnumerable<MstCustomer>> GetCustomers();
        Task<IEnumerable<MstCustomer>> GetCustomer(string name);
    }
}
