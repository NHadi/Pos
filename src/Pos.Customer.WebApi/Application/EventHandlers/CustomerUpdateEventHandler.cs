using AutoMapper;
using Dermayon.Common.CrossCutting;
using Dermayon.Common.Infrastructure.EventMessaging;
using Dermayon.Infrastructure.Data.EFRepositories.Contracts;
using Dermayon.Infrastructure.EvenMessaging.Kafka.Contracts;
using Newtonsoft.Json.Linq;
using Pos.Customer.Domain.CustomerAggregate;
using Pos.Customer.Infrastructure;
using Pos.Customer.WebApi.Application.Commands;
using Pos.Customer.WebApi.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Customer.WebApi.Application.EventHandlers
{
    public class CustomerUpdateEventHandler : IServiceEventHandler
    {
        private readonly IUnitOfWork<POSCustomerContext> _uow;
        private readonly IMapper _mapper;
        private readonly IKakfaProducer _producer;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerQueries _customerQueries;

        public CustomerUpdateEventHandler(IUnitOfWork<POSCustomerContext> uow,
            IMapper mapper,
            IKakfaProducer producer, 
            ICustomerRepository customerRepository,
            ICustomerQueries customerQueries)
        {
            _uow = uow;
            _mapper = mapper;
            _producer = producer;
            _customerRepository = customerRepository;
            _customerQueries = customerQueries;
        }
        public async Task Handle(JObject jObject, ILog log, CancellationToken cancellationToken)
        {
            try
            {
                log.Info("Consume CustomerUpdatedEvent");

                var dataConsomed = jObject.ToObject<UpdateCustomerCommand>();

                var data = await _customerQueries.GetCustomer(dataConsomed.CustomerId);
                if (data != null)
                {
                    data = _mapper.Map<MstCustomer>(dataConsomed);

                    log.Info("Update Customer");
                    //Consume data to Read Db
                    _customerRepository.Update(data);
                    await _uow.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error Updating data customer", ex);
                throw ex;
            }            
        }
    }
}
