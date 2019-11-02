using Dermayon.Common.Domain;
using Dermayon.Common.Infrastructure.Data.Contracts;
using Dermayon.Infrastructure.EvenMessaging.Kafka.Contracts;
using Pos.Customer.Domain.Events;
using Pos.Customer.Infrastructure.EventSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Customer.WebApi.Application.Commands
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand>
    {
        private readonly IKakfaProducer _kafkaProducer;
        private readonly IEventRepository<POSCustomerEventContext, CustomerCreatedEvent> _eventSources;

        public CreateCustomerCommandHandler(IKakfaProducer kakfaProducer, IEventRepository<POSCustomerEventContext, CustomerCreatedEvent> eventSources)
        {
            _kafkaProducer = kakfaProducer;
            _eventSources = eventSources;
        }

        public async Task Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customerCreatedEvent = new CustomerCreatedEvent
            {
                Address = command.Address,
                Name = command.Name,
                Phone = command.Phone,
                CreatedAt = DateTime.Now
            };

            // Insert event to Command Db
            await _eventSources.InserEvent(customerCreatedEvent, cancellationToken);
            
            await _kafkaProducer.Send(customerCreatedEvent, "PosServices");
        }
    }
}
