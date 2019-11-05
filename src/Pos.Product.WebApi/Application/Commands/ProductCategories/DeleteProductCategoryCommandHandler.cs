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
    public class DeleteProductCategoryCommandHandler : ICommandHandler<DeleteProductCategoryCommand>
    {
        private readonly IKakfaProducer _kafkaProducer;
        private readonly IEventRepository<POSProductEventContext, ProductCategoryDeletedEvent> _eventSources;
        public DeleteProductCategoryCommandHandler(IKakfaProducer kakfaProducer, 
            IEventRepository<POSProductEventContext, ProductCategoryDeletedEvent> eventSources
            )
        {
            _kafkaProducer = kakfaProducer;
            _eventSources = eventSources;
        }

        public async Task Handle(DeleteProductCategoryCommand command, CancellationToken cancellationToken)
        {
            var DeletedEvent = new ProductCategoryDeletedEvent
            {
                ProductCategoryId = command.PoductCategoryId,                
                CreatedAt = DateTime.Now
            };

            // Insert event to Command Db
            await _eventSources.InserEvent(DeletedEvent, cancellationToken);

            await _kafkaProducer.Send(DeletedEvent, "PosServices");
        }
    }
}
