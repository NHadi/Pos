using AutoMapper;
using Dermayon.Common.CrossCutting;
using Dermayon.Common.Infrastructure.EventMessaging;
using Dermayon.Infrastructure.Data.EFRepositories.Contracts;
using Dermayon.Infrastructure.EvenMessaging.Kafka.Contracts;
using Microsoft.EntityFrameworkCore;
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
    public class ProductDeleteEventHandler : IServiceEventHandler
    {
        private readonly IUnitOfWork<POSProductContext> _uow;
        private readonly IMapper _mapper;
        private readonly IKakfaProducer _producer;
        private readonly IProductRepository _ProductRepository;
        private readonly IProductQueries _ProductQueries;

        public ProductDeleteEventHandler(IUnitOfWork<POSProductContext> uow,
            IMapper mapper,
            IKakfaProducer producer,
            IProductRepository ProductRepository,
            IProductQueries ProductQueries)
        {
            _uow = uow;
            _mapper = mapper;
            _producer = producer;
            _ProductQueries = ProductQueries;
            _ProductRepository = ProductRepository;
        }
        public async Task Handle(JObject jObject, ILog log, CancellationToken cancellationToken)
        {
            try
            {
                log.Info("Consume ProductDeletedEvent");

                var dataConsomed = jObject.ToObject<DeleteProductCommand>();

                var data = await _ProductQueries.GetProduct(dataConsomed.ProductId);

                log.Info("Delete Product");

                //Consume data to Read Db
                _ProductRepository.Delete(data);
                await _uow.CommitAsync();
            }
            catch (Exception ex)
            {
                log.Error("Error Deleteing data Product", ex);
                throw ex;
            }            
        }
    }
}
