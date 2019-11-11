using Dermayon.Common.Domain;
using Pos.Event.Contracts;
using Pos.Order.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Order.WebApi.Application.Commands
{
    public class CreateOrderCommand : ICommand
    {
        public CreateOrderCommand()
        {
            OrderDetail = new List<OrderDetailDto>();
        }
        public Guid OrderId { get; set; }
        public Guid? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public decimal? Amount { get; set; }
        public string Status { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public List<OrderDetailDto> OrderDetail { get; set; }     
        
        public void AddProduct(Guid product, int? quantity, decimal? unitPrice = null)
        {
            OrderDetail.Add(new OrderDetailDto { ProductId = product, Quantity = quantity, UnitPrice = unitPrice });
        }
    }  
}
