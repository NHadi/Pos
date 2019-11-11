using Dermayon.Common.Domain;
using Dermayon.Common.Infrastructure.Data.Contracts;
using Dermayon.Infrastructure.EvenMessaging.Kafka.Contracts;
using Pos.Customer.WebApi.Application.Commands;
using Pos.Event.Contracts;
using Pos.Product.Infrastructure.EventSources;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Product.WebApi.Application.Commands
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly IKakfaProducer _kafkaProducer;
        private readonly IEventRepository<POSProductEventContext, ProductDeletedEvent> _eventSources;
        public DeleteProductCommandHandler(IKakfaProducer kakfaProducer, 
            IEventRepository<POSProductEventContext, ProductDeletedEvent> eventSources
            )
        {
            _kafkaProducer = kakfaProducer;
            _eventSources = eventSources;
        }

        public async Task Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var DeletedEvent = new ProductDeletedEvent
            {
                ProductId = command.ProductId,                
                CreatedAt = DateTime.Now
            };

            // Insert event to Command Db
            await _eventSources.InserEvent(DeletedEvent, cancellationToken);

            await _kafkaProducer.Send(DeletedEvent, AppGlobalTopic.PosTopic);
        }
    }
}
