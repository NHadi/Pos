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
    public class ProductCategoryCreateEventHandler : IServiceEventHandler
    {
        private readonly IUnitOfWork<POSProductContext> _uow;
        private readonly IMapper _mapper;
        private readonly IKakfaProducer _producer;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryCreateEventHandler(IUnitOfWork<POSProductContext> uow,
            IMapper mapper,
            IKakfaProducer producer,
            IProductCategoryRepository productCategoryRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _producer = producer;
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task Handle(JObject jObject, ILog log, CancellationToken cancellationToken)
        {
            try
            {
                log.Info("Consume ProductCategoryCreatedEvent");

                var dataConsomed = jObject.ToObject<ProductCategoryCreatedEvent>();
                var data = _mapper.Map<ProductCategory>(dataConsomed);

                log.Info("Insert ProductCategory");

                //Consume data to Read Db
                _productCategoryRepository.Insert(data);
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                log.Error("Error Inserting data ProductCategory", ex);
                throw ex;
            }            
        }
    }
}
