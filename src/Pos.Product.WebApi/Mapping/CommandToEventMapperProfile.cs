using AutoMapper;
using Pos.Customer.WebApi.Application.Commands;
using Pos.Product.Domain.Events;
using Pos.Product.Domain.ProductAggregate;
using Pos.Product.WebApi.Application.Commands;
using Pos.Product.WebApi.Application.Commands.ProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Product.WebApi.Mapping
{
    public class CommandToEventMapperProfile : Profile
    {
        public CommandToEventMapperProfile()
        {
            CreateMap<CreateProductCommand, ProductCreatedEvent>();
            CreateMap<UpdateProductCommand, ProductUpdatedEvent>();                
            CreateMap<DeleteProductCommand, ProductDeletedEvent>();

            CreateMap<CreateProductCategoryCommand, ProductCategoryCreatedEvent>();
            CreateMap<UpdateProductCategoryCommand, ProductCategoryUpdatedEvent>();
            CreateMap<DeleteProductCategoryCommand, ProductCategoryDeletedEvent>();
        }
    }
}
