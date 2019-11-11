using AutoMapper;
using Pos.Order.Domain;
using Pos.Order.WebApi.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Order.WebApi.Mapping
{
    public class AllToDtoMapperProfile : Profile
    {
        public AllToDtoMapperProfile()
        {
            CreateMap<MstOrder, DetailOrderResponse>();
            CreateMap<OrderDetail, DetailOrderLineItemResponse>();


        }
    }
}
