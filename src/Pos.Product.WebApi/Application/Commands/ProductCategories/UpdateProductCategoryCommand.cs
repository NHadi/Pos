using Dermayon.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Customer.WebApi.Application.Commands
{
    public class UpdateProductCategoryCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
