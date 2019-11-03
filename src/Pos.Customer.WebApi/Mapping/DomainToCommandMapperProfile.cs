using AutoMapper;
using Pos.Customer.Domain.CustomerAggregate;
using Pos.Customer.WebApi.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Customer.WebApi.Mapping
{
    public class DomainToCommandMapperProfile : Profile
    {
        public DomainToCommandMapperProfile()
        {

            CreateMap<MstCustomer, DeleteCustomerCommand>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id));
            
        }
    }
}
