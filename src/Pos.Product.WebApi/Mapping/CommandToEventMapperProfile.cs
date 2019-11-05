using AutoMapper;
using Pos.Customer.WebApi.Application.Commands;
using Pos.Event.Contracts;
using Pos.Product.WebApi.Application.Commands;
using Pos.Product.WebApi.Application.Commands.ProductCategories;

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
