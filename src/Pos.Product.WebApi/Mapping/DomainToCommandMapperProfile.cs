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
    public class DomainToCommandMapperProfile : Profile
    {
        public DomainToCommandMapperProfile()
        {            
            CreateMap<MstProduct, CreateProductCommand>();
            CreateMap<MstProduct, UpdateProductCommand>();
            CreateMap<MstProduct, DeleteProductCommand>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id));

            CreateMap<ProductCategory, CreateProductCategoryCommand>();
            CreateMap<ProductCategory, UpdateProductCategoryCommand>();
            CreateMap<ProductCategory, DeleteProductCategoryCommand>()
                .ForMember(dest => dest.PoductCategoryId, opt => opt.MapFrom(src => src.Id));


        }
    }
}
