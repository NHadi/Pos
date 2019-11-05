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
    public class OrderShippedEventHandler : IServiceEventHandler
    {
        private readonly IKakfaProducer _producer;
        private readonly IUnitOfWork<POSOrderContext> _uow;
        private readonly IOrderRepository _orderRepository;
        public OrderShippedEventHandler(IKakfaProducer producer,
            IOrderRepository orderRepository
            )
        {
            _producer = producer;
            _orderRepository = orderRepository;
        }

        public async Task Handle(JObject jObject, ILog log, CancellationToken cancellationToken)
        {
            try
            {
                log.Info("Consume Event");

                var dataConsomed = jObject.ToObject<OrderShippedEvent>();

                //Consume data to Read Db
                await _orderRepository.ShippedOrder(dataConsomed.OrderId);
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }           
        }
    }
}
