using AutoMapper;
using Dermayon.Common.CrossCutting;
using Dermayon.Common.Infrastructure.EventMessaging;
using Dermayon.Infrastructure.Data.EFRepositories.Contracts;
using Dermayon.Infrastructure.EvenMessaging.Kafka.Contracts;
using Newtonsoft.Json.Linq;
using Pos.Customer.WebApi.Application.Commands;
using Pos.Product.Domain.ProductAggregate;
using Pos.Product.Domain.ProductAggregate.Contracts;
using Pos.Product.Infrastructure;
using Pos.Product.WebApi.Application.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Customer.WebApi.Application.EventHandlers
{
    public class ProductCategoryUpdateEventHandler : IServiceEventHandler
    {
        private readonly IUnitOfWork<POSProductContext> _uow;
        private readonly IMapper _mapper;
        private readonly IKakfaProducer _producer;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductCategoryQueries _productCategoryQueries;

        public ProductCategoryUpdateEventHandler(IUnitOfWork<POSProductContext> uow,
            IMapper mapper,
            IKakfaProducer producer,
            IProductCategoryRepository productCategoryRepository,
            IProductCategoryQueries productCategoryQueries)
        {
            _uow = uow;
            _mapper = mapper;
            _producer = producer;
            _productCategoryRepository = productCategoryRepository;
            _productCategoryQueries = productCategoryQueries;
        }
        public async Task Handle(JObject jObject, ILog log, CancellationToken cancellationToken)
        {
            try
            {
                log.Info("Consume ProductCategoryUpdatedEvent");

                var dataConsomed = jObject.ToObject<UpdateProductCategoryCommand>();

                var data = await _productCategoryQueries.GetData(dataConsomed.Id);
                if (data != null)
                {
                    data = _mapper.Map<ProductCategory>(dataConsomed);

                    log.Info("Update ProductCategory");
                    //Consume data to Read Db
                    _productCategoryRepository.Update(data);
                    await _uow.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error Updating data ProductCategory", ex);
                throw ex;
            }            
        }
    }
}
