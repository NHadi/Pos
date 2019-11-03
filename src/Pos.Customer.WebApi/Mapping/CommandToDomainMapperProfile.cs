using AutoMapper;
using Pos.Customer.Domain.CustomerAggregate;
using Pos.Customer.WebApi.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Customer.WebApi.Mapping
{
    public class CommandToDomainMapperProfile : Profile
    {
        public CommandToDomainMapperProfile()
        {
            CreateMap<CreateCustomerCommand, MstCustomer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()));

            CreateMap<UpdateCustomerCommand, MstCustomer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CustomerId));                

            CreateMap<DeleteCustomerCommand, MstCustomer>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CustomerId));
            
        }
    }
}
