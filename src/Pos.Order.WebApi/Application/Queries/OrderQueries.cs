using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dermayon.Common.Infrastructure.Data.Contracts;
using Dermayon.Infrastructure.Data.DapperRepositories;
using Microsoft.EntityFrameworkCore;
using Pos.Order.Domain;
using Pos.Order.Domain.OrderAggregate.Contract;

namespace Pos.Customer.WebApi.Application.Queries
{
    public class OrderQueries : IOrderQueries
    {
        private readonly IDbConectionFactory _dbConectionFactory;
        private readonly IOrderRepository _orderRepository;

        public OrderQueries(IDbConectionFactory dbConectionFactory,
            IOrderRepository orderRepository)
        {
            _dbConectionFactory = dbConectionFactory;
            _orderRepository = orderRepository;
        }


        public async Task<MstOrder> GetOrder(Guid id)
        {
            var data = await _orderRepository.GetIncludeAsync(x => x.Id == id, includes: src => src.Include(x => x.OrderDetail));

            return data.SingleOrDefault();
        }

        public async Task<IEnumerable<MstOrder>> GetOrderByNumber(string orderNumber)
        {
            var data = await _orderRepository.GetIncludeAsync(x => x.OrderNumber == orderNumber, includes: src => src.Include(x => x.OrderDetail));

            return data.ToList();
        }

        public async Task<IEnumerable<MstOrder>> GetOrders()
        {
            var data = await _orderRepository.GetIncludeAsync(null, includes: src => src.Include(x => x.OrderDetail));

            return data.ToList();
        }
    }
}
