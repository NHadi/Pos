using AutoMapper;
using Dermayon.Common.CrossCutting;
using Dermayon.Common.Infrastructure.EventMessaging;
using Dermayon.Infrastructure.EvenMessaging.Kafka.Contracts;
using Newtonsoft.Json.Linq;
using Pos.Customer.WebApi.Application.Queries;
using Pos.Event.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Product.WebApi.Application.EventHandlers.SagaPattern
{
    public class OrderCreatedEventHandler : IServiceEventHandler
    {
        private readonly IMapper _mapper;
        private readonly IKakfaProducer _producer;
        private readonly IProductQueries _productQueries;

        public OrderCreatedEventHandler(
            IMapper mapper,
            IKakfaProducer producer,
            IProductQueries productQueries)
        {
            _mapper = mapper;
            _producer = producer;
            _productQueries = productQueries;
        }
        public async Task Handle(JObject jObject, ILog log, CancellationToken cancellationToken)
        {
            try
            {
                bool orderIsValid = true;
                string message = null;

                log.Info("Consume OrderCreatedEvent");

                var dataConsomed = jObject.ToObject<OrderCreatedEvent>();

                var allProduct = dataConsomed.OrderItems
                    .Select(x => x.PartNumber)
                    .ToList();

                //Consume data and validate the data
                allProduct.ForEach(async item =>
                {
                    var dataIsExist = await _productQueries.GetProductByPartNumber(item);
                    if (dataIsExist == null)
                        orderIsValid = false;                    
                });
                
                if (orderIsValid == false)
                {
                    message = "Customer not found";
                }

                var @event = new OrderValidatedEvent { OrderId = dataConsomed.OrderId, IsValid = orderIsValid, Messages = new List<string> { message } };

                await _producer.Send(@event, "PosServices");
            }
            catch (Exception ex)
            {
                log.Error("Error Validating order by product", ex);
                throw ex;
            }
        }
    }
}
