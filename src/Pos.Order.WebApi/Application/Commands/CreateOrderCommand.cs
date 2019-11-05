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
            OrderItems = new List<OrderDetailCommand>();
        }
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
        public List<OrderDetailCommand> OrderItems { get; set; }     
        
        public void AddProduct(Guid product, int? quantity, decimal? unitPrice = null)
        {
            OrderItems.Add(new OrderDetailCommand { ProductId = product, Quantity = quantity, UnitPrice = unitPrice });
        }
    }

    public class OrderDetailCommand
    {
        public Guid ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }        
    }
}
