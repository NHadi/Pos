using Dermayon.Infrastructure.Data.EFRepositories;
using Pos.Order.Domain;
using Pos.Order.Domain.OrderAggregate.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Order.Infrastructure.Repositories
{
    public class OrderRepository : EfRepository<MstOrder>, IOrderRepository
    {
        private readonly POSOrderContext _context;        
        public OrderRepository(POSOrderContext context) : base(context)
        {
            _context = context;
        }

        public async Task CanceledOrder(Guid orderId)
        {
            var result = await GetAsync(x => x.Id == orderId);

            var data = result.SingleOrDefault();
            if (data != null)
            {
                data.Status = "Canceled";
                Update(data);
            }            
        }

        public async Task ShippedOrder(Guid orderId)
        {
            var result = await GetAsync(x => x.Id == orderId);

            var data = result.SingleOrDefault();
            if (data != null)
            {
                data.Status = "Shipped";
                Update(data);
            }
        }
    }
}
