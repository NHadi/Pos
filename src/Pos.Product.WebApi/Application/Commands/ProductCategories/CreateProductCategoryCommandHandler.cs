using AutoMapper;
using Dermayon.Common.Domain;
using Dermayon.Common.Infrastructure.Data.Contracts;
using Dermayon.Infrastructure.EvenMessaging.Kafka.Contracts;
using Pos.Event.Contracts;
using Pos.Product.Infrastructure.EventSources;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Product.WebApi.Application.Commands.ProductCategories
{
    public class CreateProductCategoryCommandHandler : ICommandHandler<CreateProductCategoryCommand>
    {
        private readonly IMapper _mapper;
        private readonly IKakfaProducer _kafkaProducer;
        private readonly IEventRepository<POSProductEventContext, ProductCategoryCreatedEvent> _eventSources;

        public CreateProductCategoryCommandHandler(
            IMapper mapper,
            IKakfaProducer kakfaProducer, 
            IEventRepository<POSProductEventContext, ProductCategoryCreatedEvent> eventSources)
        {
            _mapper = mapper;
            _kafkaProducer = kakfaProducer;
            _eventSources = eventSources;
        }

        public async Task Handle(CreateProductCategoryCommand command, CancellationToken cancellationToken)
        {
            var createdEvent = _mapper.Map<ProductCategoryCreatedEvent>(command);
            createdEvent.CreatedAt = DateTime.Now;

            // Insert event to Command Db
            await _eventSources.InserEvent(createdEvent, cancellationToken);
            
            await _kafkaProducer.Send(createdEvent, "PosServices");
        }
    }
}
