using AutoMapper;
using Dermayon.Common.CrossCutting;
using Dermayon.Common.Infrastructure.EventMessaging;
using Dermayon.Infrastructure.Data.EFRepositories.Contracts;
using Dermayon.Infrastructure.EvenMessaging.Kafka.Contracts;
using Newtonsoft.Json.Linq;
using Pos.Customer.WebApi.Application.Commands;
using Pos.Customer.WebApi.Application.Queries;
using Pos.Product.Domain.ProductAggregate;
using Pos.Product.Domain.ProductAggregate.Contracts;
using Pos.Product.Infrastructure;
using Pos.Product.WebApi.Application.Commands;
using Pos.Product.WebApi.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Product.WebApi.Application.EventHandlers
{
    public class ProductUpdateEventHandler : IServiceEventHandler
    {
        private readonly IUnitOfWork<POSProductContext> _uow;
        private readonly IMapper _mapper;
        private readonly IKakfaProducer _producer;
        private readonly IProductRepository _ProductRepository;
        private readonly IProductQueries _ProductQueries;

        public ProductUpdateEventHandler(IUnitOfWork<POSProductContext> uow,
            IMapper mapper,
            IKakfaProducer producer, 
            IProductRepository ProductRepository,
            IProductQueries ProductQueries)
        {
            _uow = uow;
            _mapper = mapper;
            _producer = producer;
            _ProductRepository = ProductRepository;
            _ProductQueries = ProductQueries;
        }
        public async Task Handle(JObject jObject, ILog log, CancellationToken cancellationToken)
        {
            try
            {
                log.Info("Consume ProductUpdatedEvent");

                var dataConsomed = jObject.ToObject<UpdateProductCommand>();

                var data = await _ProductQueries.GetProduct(dataConsomed.Id);
                if (data != null)
                {
                    data = _mapper.Map<MstProduct>(dataConsomed);

                    log.Info("Update Product");
                    //Consume data to Read Db
                    _ProductRepository.Update(data);
                    await _uow.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                log.Error("Error Updating data Product", ex);
                throw ex;
            }            
        }
    }
}
