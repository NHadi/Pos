using Dermayon.Infrastructure.Data.EFRepositories.Contracts;
using System;
using System.Threading.Tasks;

namespace Pos.Order.Domain.OrderAggregate.Contract
{
    public interface IOrderRepository : IEfRepository<MstOrder>
    {
        Task ShippedOrder(Guid orderId);
        Task CanceledOrder(Guid orderId);
    }
}
