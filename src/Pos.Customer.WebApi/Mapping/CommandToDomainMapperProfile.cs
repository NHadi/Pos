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
                .ForMember(x => x.Id, o => o.MapFrom(s => Guid.NewGuid()));                
        }
    }
}
