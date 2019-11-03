using Dermayon.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Product.WebApi.Application.Commands.ProductCategories
{
    public class CreateProductCategoryCommand : ICommand
    {
        public string Name { get; set; }
    }
}
