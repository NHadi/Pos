using AutoMapper;
using Pos.Customer.Domain.CustomerAggregate;
using Pos.Event.Contracts;
using System;

namespace Pos.Customer.WebApi.Mapping
{
    public class EventoDomainMapperProfile : Profile
    {
        public EventoDomainMapperProfile()
        {
            CreateMap<CustomerCreatedEvent, MstCustomer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<CustomerUpdatedEvent, MstCustomer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CustomerId));                        
        }
    }
}
