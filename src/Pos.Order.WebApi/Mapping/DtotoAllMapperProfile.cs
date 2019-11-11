using AutoMapper;
using Pos.Order.Domain.OrderAggregate;
using Pos.Event.Contracts;
using System;
using Pos.Order.Domain;
using Pos.Order.WebApi.Application.Commands;
using Pos.Order.WebApi.Application.DTO;
using System.IO;

namespace Pos.Order.WebApi.Mapping
{
    public class DtotoAllMapperProfile : Profile
    {
        public DtotoAllMapperProfile()
        {
            CreateMap<OrderDetailDto, OrderDetail>();
            CreateMap<CreateOrderHeaderRequest, CreateOrderCommand>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => Path.GetRandomFileName().Replace(".", "")))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "Pending"))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => DateTime.Now));


        }
    }
}
