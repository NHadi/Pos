using AutoMapper;
using Pos.Customer.WebApi.Application.Commands;
using Pos.Event.Contracts;

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
