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
    public class EventToDomainMapperProfile : Profile
    {
        public EventToDomainMapperProfile()
        {
            CreateMap<ProductCreatedEvent, MstProduct>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<ProductUpdatedEvent, MstProduct>();                            

            CreateMap<ProductCategoryCreatedEvent, ProductCategory>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<ProductCategoryUpdatedEvent, ProductCategory>();            
        }
    }
}
