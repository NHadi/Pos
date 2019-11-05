using AutoMapper;
using Pos.Event.Contracts;
using Pos.Product.Domain.ProductAggregate;
using System;

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
