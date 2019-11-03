using AutoMapper;
using Dermayon.Common.Domain;
using Dermayon.Common.Infrastructure.Data.Contracts;
using Dermayon.Infrastructure.EvenMessaging.Kafka.Contracts;
using Pos.Customer.WebApi.Application.Commands;
using Pos.Product.Domain.Events;
using Pos.Product.Infrastructure.EventSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Product.WebApi.Application.Commands
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly IKakfaProducer _kafkaProducer;
        private readonly IEventRepository<POSProductEventContext, ProductUpdatedEvent> _eventSources;

        public UpdateProductCommandHandler(
            IMapper mapper,
            IKakfaProducer kakfaProducer, 
            IEventRepository<POSProductEventContext, ProductUpdatedEvent> eventSources)
        {
            _mapper = mapper;
            _kafkaProducer = kakfaProducer;
            _eventSources = eventSources;
        }

        public async Task Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var updatedEvent = _mapper.Map<ProductUpdatedEvent>(command);
            updatedEvent.CreatedAt = DateTime.Now;

            // Insert event to Command Db
            await _eventSources.InserEvent(updatedEvent, cancellationToken);

            await _kafkaProducer.Send(updatedEvent, "PosServices");
        }
    }
}
