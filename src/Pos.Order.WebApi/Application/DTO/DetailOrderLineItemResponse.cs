using System;

namespace Pos.Order.WebApi.Application.DTO
{
    public class DetailOrderLineItemResponse
    {
        public Guid ProductId { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}