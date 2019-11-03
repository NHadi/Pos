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
    public class CommandToEventMapperProfile : Profile
    {
        public CommandToEventMapperProfile()
        {
            CreateMap<CreateCustomerCommand, CustomerCreatedEvent>();
            CreateMap<UpdateCustomerCommand, CustomerUpdatedEvent>();

        }
    }
}
