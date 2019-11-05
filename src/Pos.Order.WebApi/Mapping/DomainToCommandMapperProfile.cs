using AutoMapper;
using Pos.Order.Domain;
using Pos.Order.Domain.OrderAggregate;
using Pos.Order.WebApi.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Order.WebApi.Mapping
{
    public class DomainToCommandMapperProfile : Profile
    {
        public DomainToCommandMapperProfile()
        {
            CreateMap<MstOrder, CreateOrderCommand>();            
        }
    }
}
