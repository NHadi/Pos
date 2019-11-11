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
    public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
    {
        private readonly IKakfaProducer _kafkaProducer;
        private readonly IEventRepository<POSCustomerEventContext, CustomerUpdatedEvent> _eventSources;

        public UpdateCustomerCommandHandler(IKakfaProducer kakfaProducer, IEventRepository<POSCustomerEventContext, CustomerUpdatedEvent> eventSources)
        {
            _kafkaProducer = kakfaProducer;
            _eventSources = eventSources;
        }

        public async Task Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var updatedEvent = new CustomerUpdatedEvent
            {
                CustomerId = command.CustomerId,
                Address = command.Address,
                Name = command.Name,
                Phone = command.Phone,
                CreatedAt = DateTime.Now
            };

            // Insert event to Command Db
            await _eventSources.InserEvent(updatedEvent, cancellationToken);

            await _kafkaProducer.Send(updatedEvent, AppGlobalTopic.PosTopic);
        }
    }
}
