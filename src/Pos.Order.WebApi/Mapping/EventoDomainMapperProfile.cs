using AutoMapper;
using Pos.Order.Domain.OrderAggregate;
using Pos.Event.Contracts;
using System;
using Pos.Order.Domain;

namespace Pos.Order.WebApi.Mapping
{
    public class EventoDomainMapperProfile : Profile
    {
        public EventoDomainMapperProfile()
        {
            CreateMap<OrderCreatedEvent, MstOrder>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderId));
                            
        }
    }
}
