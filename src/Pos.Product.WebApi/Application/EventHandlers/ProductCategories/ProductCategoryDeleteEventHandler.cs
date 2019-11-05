using AutoMapper;
using Dermayon.Common.CrossCutting;
using Dermayon.Common.Infrastructure.EventMessaging;
using Dermayon.Infrastructure.Data.EFRepositories.Contracts;
using Dermayon.Infrastructure.EvenMessaging.Kafka.Contracts;
using Newtonsoft.Json.Linq;
using Pos.Event.Contracts;
using Pos.Product.Domain.ProductAggregate.Contracts;
using Pos.Product.Infrastructure;
using Pos.Product.WebApi.Application.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Customer.WebApi.Application.EventHandlers
{
    public class ProductCategoryDeleteEventHandler : IServiceEventHandler
    {
        private readonly IUnitOfWork<POSProductContext> _uow;
        private readonly IMapper _mapper;
        private readonly IKakfaProducer _producer;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductCategoryQueries _productCategoryQueries;

        public ProductCategoryDeleteEventHandler(IUnitOfWork<POSProductContext> uow,
            IMapper mapper,
            IKakfaProducer producer,
            IProductCategoryRepository productCategoryRepository,
            IProductCategoryQueries productCategoryQueries)
        {
            _uow = uow;
            _mapper = mapper;
            _producer = producer;
            _productCategoryQueries = productCategoryQueries;
            _productCategoryRepository = productCategoryRepository;
        }
        public async Task Handle(JObject jObject, ILog log, CancellationToken cancellationToken)
        {
            try
            {
                log.Info("Consume DeletedEvent");

                var dataConsomed = jObject.ToObject<ProductCategoryDeletedEvent>();

                var data = await _productCategoryQueries.GetData(dataConsomed.ProductCategoryId);

                log.Info("Delete Customer");

                //Consume data to Read Db
                _productCategoryRepository.Delete(data);
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                log.Error("Error Deleteing data customer", ex);
                throw ex;
            }            
        }
    }
}
