using Dermayon.Infrastructure.Data.EFRepositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Customer.Domain.CustomerAggregate
{
    public interface ICustomerRepository : IEfRepository<MstCustomer>
    {
    }
}
