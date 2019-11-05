using Pos.Order.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pos.Customer.WebApi.Application.Queries
{
    public interface IOrderQueries
    {
        Task<IEnumerable<MstOrder>> GetOrders();
        Task<MstOrder> GetOrder(Guid id);
        Task<IEnumerable<MstOrder>> GetOrderByNumber(string orderNumber);        
    }
}
