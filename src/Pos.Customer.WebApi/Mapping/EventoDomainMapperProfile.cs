using AutoMapper;
using Pos.Customer.Domain.CustomerAggregate;
using Pos.Customer.Domain.Events;
using Pos.Customer.WebApi.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
