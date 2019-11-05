using Dermayon.Common.Domain;
using Dermayon.Common.Infrastructure.Data.Contracts;
using Dermayon.Infrastructure.EvenMessaging.Kafka.Contracts;
using Pos.Customer.Infrastructure.EventSources;
using Pos.Event.Contracts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Customer.WebApi.Application.Commands
{
    public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand>
    {
        private readonly IKakfaProducer _kafkaProducer;
        private readonly IEventRepository<POSCustomerEventContext, CustomerDeletedEvent> _eventSources;
        public DeleteCustomerCommandHandler(IKakfaProducer kakfaProducer, 
            IEventRepository<POSCustomerEventContext, CustomerDeletedEvent> eventSources
            )
        {
            _kafkaProducer = kakfaProducer;
            _eventSources = eventSources;
        }

        public async Task Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            var DeletedEvent = new CustomerDeletedEvent
            {
                CustomerId = command.CustomerId,                
                CreatedAt = DateTime.Now
            };

            // Insert event to Command Db
            await _eventSources.InserEvent(DeletedEvent, cancellationToken);

            await _kafkaProducer.Send(DeletedEvent, "PosServices");
        }
    }
}
