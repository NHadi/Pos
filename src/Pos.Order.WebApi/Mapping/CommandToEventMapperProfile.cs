using AutoMapper;
using Pos.Order.WebApi.Application.Commands;
using Pos.Event.Contracts;

namespace Pos.Order.WebApi.Mapping
{
    public class CommandToEventMapperProfile : Profile
    {
        public CommandToEventMapperProfile()
        {
            CreateMap<CreateOrderCommand, OrderCreatedEvent>();            

        }
    }
}
