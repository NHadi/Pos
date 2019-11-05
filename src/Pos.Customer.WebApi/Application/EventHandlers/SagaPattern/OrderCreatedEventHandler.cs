using AutoMapper;
using Dermayon.Common.CrossCutting;
using Dermayon.Common.Infrastructure.EventMessaging;
using Dermayon.Infrastructure.Data.EFRepositories.Contracts;
using Dermayon.Infrastructure.EvenMessaging.Kafka.Contracts;
using Newtonsoft.Json.Linq;
using Pos.Customer.WebApi.Application.Queries;
using Pos.Event.Contracts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Customer.WebApi.Application.EventHandlers.SagaPattern
{
    public class OrderCreatedEventHandler : IServiceEventHandler
    {
        private readonly IMapper _mapper;
        private readonly IKakfaProducer _producer;
        private readonly ICustomerQueries _customerQueries;

        public OrderCreatedEventHandler(
            IMapper mapper,
            IKakfaProducer producer,
            ICustomerQueries customerQueries)
        {            
            _mapper = mapper;
            _producer = producer;
            _customerQueries = customerQueries;
        }
        public async Task Handle(JObject jObject, ILog log, CancellationToken cancellationToken)
        {
            try
            {
                bool orderIsValid = true;
                string message = null;

                log.Info("Consume OrderCreatedEvent");

                var dataConsomed = jObject.ToObject<OrderCreatedEvent>();
                //Consume data and validate the data
                var dataIsExist = await _customerQueries.GetCustomer(dataConsomed.CustomerId);

                if (dataIsExist != null)
                {
                    orderIsValid = false;
                    message = "Customer not found";
                }

                var @event = new OrderValidatedEvent { OrderId = dataConsomed.OrderId, IsValid = orderIsValid, Messages = new List<string> { message } };

                await _producer.Send(@event, "PosServices");
            }
            catch (Exception ex)
            {
                log.Error("Error Validating order by customer", ex);
                throw ex;
            }            
        }
    }
}
