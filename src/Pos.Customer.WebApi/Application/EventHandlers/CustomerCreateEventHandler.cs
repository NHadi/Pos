using AutoMapper;
using Dermayon.Common.CrossCutting;
using Dermayon.Common.Infrastructure.EventMessaging;
using Dermayon.Infrastructure.Data.EFRepositories.Contracts;
using Dermayon.Infrastructure.EvenMessaging.Kafka.Contracts;
using Newtonsoft.Json.Linq;
using Pos.Customer.Domain.CustomerAggregate;
using Pos.Customer.Infrastructure;
using Pos.Customer.WebApi.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Customer.WebApi.Application.EventHandlers
{
    public class CustomerCreateEventHandler : IServiceEventHandler
    {
        private readonly IUnitOfWork<POSCustomerContext> _uow;
        private readonly IMapper _mapper;
        private readonly IKakfaProducer _producer;
        private readonly ICustomerRepository _customerRepository;

        public CustomerCreateEventHandler(IUnitOfWork<POSCustomerContext> uow,
            IMapper mapper,
            IKakfaProducer producer, 
            ICustomerRepository customerRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _producer = producer;
            _customerRepository = customerRepository;
        }
        public async Task Handle(JObject jObject, ILog log, CancellationToken cancellationToken)
        {
            try
            {
                log.Info("Consume CustomerCreatedEvent");

                var dataConsomed = jObject.ToObject<CreateCustomerCommand>();
                var data = _mapper.Map<MstCustomer>(dataConsomed);

                log.Info("Insert Customer");

                //Consume data to Read Db
                _customerRepository.Insert(data);
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                log.Error("Error Inserting data customer", ex);
                throw ex;
            }            
        }
    }
}
