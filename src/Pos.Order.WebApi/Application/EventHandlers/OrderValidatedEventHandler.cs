using Dermayon.Common.CrossCutting;
using Dermayon.Common.Infrastructure.Data.Contracts;
using Dermayon.Common.Infrastructure.EventMessaging;
using Dermayon.Infrastructure.Data.EFRepositories.Contracts;
using Dermayon.Infrastructure.EvenMessaging.Kafka.Contracts;
using Newtonsoft.Json.Linq;
using Pos.Event.Contracts;
using Pos.Event.Contracts.order;
using Pos.Order.Domain.OrderAggregate.Contract;
using Pos.Order.Infrastructure;
using Pos.Order.Infrastructure.EventSources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Order.WebApi.Application.EventHandlers
{
    public class OrderValidatedEventHandler : IServiceEventHandler
    {
        private readonly IKakfaProducer _producer;
        private readonly IEventRepository<POSOrderEventContext, OrderShippedEvent> _shipedEventSources;
        private readonly IEventRepository<POSOrderEventContext, OrderCancelledEvent> _cancelledEventSources;
        private readonly IUnitOfWork<POSOrderContext> _uow;
        private readonly IOrderRepository _orderRepository;
        public OrderValidatedEventHandler(IKakfaProducer producer,
            IEventRepository<POSOrderEventContext, OrderShippedEvent> shipedEventSources,
            IEventRepository<POSOrderEventContext, OrderCancelledEvent> cancelledEventSources)
        {
            _producer = producer;
            _shipedEventSources = shipedEventSources;
            _cancelledEventSources = cancelledEventSources;
        }

        public async Task Handle(JObject jObject, ILog log, CancellationToken cancellationToken)
        {
            var orderValidated = jObject.ToObject<OrderValidatedEvent>();
            if (orderValidated.IsValid)
            {
                var orderShippedEvent = new OrderShippedEvent{OrderId = orderValidated.OrderId};
                await _shipedEventSources.InserEvent(orderShippedEvent, cancellationToken);

                await _producer.Send(orderShippedEvent, "PosServices");
            }
            else
            {
                var orderCanceledEvent = new OrderCancelledEvent { OrderId = orderValidated.OrderId };
                await _cancelledEventSources.InserEvent(orderCanceledEvent, cancellationToken);

                await _producer.Send(orderCanceledEvent, "PosServices");
            }
        }
    }
}
