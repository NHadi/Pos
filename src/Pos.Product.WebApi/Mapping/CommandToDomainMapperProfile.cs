using AutoMapper;
using Pos.Customer.WebApi.Application.Commands;
using Pos.Product.Domain.ProductAggregate;
using Pos.Product.WebApi.Application.Commands;
using Pos.Product.WebApi.Application.Commands.ProductCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Product.WebApi.Mapping
{
    public class CommandToDomainMapperProfile : Profile
    {
        public CommandToDomainMapperProfile()
        {
            CreateMap<CreateProductCommand, MstProduct>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<UpdateProductCommand, MstProduct>();                
            CreateMap<DeleteProductCommand, MstProduct>();

            CreateMap<CreateProductCategoryCommand, ProductCategory>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<UpdateProductCategoryCommand, ProductCategory>();
            CreateMap<DeleteProductCategoryCommand, ProductCategory>();
        }
    }
}
