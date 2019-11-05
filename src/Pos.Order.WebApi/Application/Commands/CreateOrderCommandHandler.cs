using AutoMapper;
using Dermayon.Common.Domain;
using Dermayon.Common.Infrastructure.Data.Contracts;
using Dermayon.Infrastructure.Data.EFRepositories.Contracts;
using Dermayon.Infrastructure.EvenMessaging.Kafka.Contracts;
using Pos.Event.Contracts;
using Pos.Order.Domain;
using Pos.Order.Domain.OrderAggregate.Contract;
using Pos.Order.Infrastructure;
using Pos.Order.Infrastructure.EventSources;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Order.WebApi.Application.Commands
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly IMapper _mapper;
        private readonly IKakfaProducer _kafkaProducer;
        private readonly IEventRepository<POSOrderEventContext, OrderCreatedEvent> _eventSources;
        private readonly IUnitOfWork<POSOrderContext> _uow;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IMapper mapper,
            IKakfaProducer kakfaProducer, 
            IEventRepository<POSOrderEventContext, OrderCreatedEvent> eventSources,
            IUnitOfWork<POSOrderContext> uow,
            IOrderRepository orderRepository
            )
        {
            _mapper = mapper;
            _kafkaProducer = kakfaProducer;
            _eventSources = eventSources;
            _uow = uow;
            _orderRepository = orderRepository;
        }

        public async Task Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var @event = _mapper.Map<OrderCreatedEvent>(command);            
            // Insert event to Command Db
            await _eventSources.InserEvent(@event, cancellationToken);          
            await _kafkaProducer.Send(@event, "PosServices");

            //implement choreography saga needed
            var data = _mapper.Map<MstOrder>(command);
            _orderRepository.Insert(data);
            await _uow.CommitAsync();
        }
    }
}
