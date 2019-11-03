using Dermayon.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Product.WebApi.Application.Commands
{
    public class CreateProductCommand : ICommand
    {
        public Guid Category { get; set; }
        public string PartNumber { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
