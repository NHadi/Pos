using AutoMapper;
using Dermayon.Common.CrossCutting;
using Dermayon.Common.Infrastructure.EventMessaging;
using Dermayon.Infrastructure.Data.EFRepositories.Contracts;
using Dermayon.Infrastructure.EvenMessaging.Kafka.Contracts;
using Newtonsoft.Json.Linq;
using Pos.Event.Contracts;
using Pos.Product.Domain.ProductAggregate;
using Pos.Product.Domain.ProductAggregate.Contracts;
using Pos.Product.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Product.WebApi.Application.EventHandlers
{
    public class ProductCreateEventHandler : IServiceEventHandler
    {
        private readonly IUnitOfWork<POSProductContext> _uow;
        private readonly IMapper _mapper;
        private readonly IKakfaProducer _producer;
        private readonly IProductRepository _ProductRepository;

        public ProductCreateEventHandler(IUnitOfWork<POSProductContext> uow,
            IMapper mapper,
            IKakfaProducer producer, 
            IProductRepository ProductRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _producer = producer;
            _ProductRepository = ProductRepository;
        }
        public async Task Handle(JObject jObject, ILog log, CancellationToken cancellationToken)
        {
            try
            {
                log.Info("Consume ProductCreatedEvent");

                var dataConsomed = jObject.ToObject<ProductCreatedEvent>();
                var data = _mapper.Map<MstProduct>(dataConsomed);

                log.Info("Insert Product");

                //Consume data to Read Db
                _ProductRepository.Insert(data);
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                log.Error("Error Inserting data Product", ex);
                throw ex;
            }            
        }
    }
}
