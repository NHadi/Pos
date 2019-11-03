using AutoMapper;
using Dermayon.Common.Domain;
using Dermayon.Infrastructure.EvenMessaging.Kafka;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pos.Product.Domain.Events;
using Pos.Product.Infrastructure;
using Pos.Product.Infrastructure.EventSources;
using Pos.Product.Infrastructure.Repositories;
using Pos.Product.WebApi.Application.Commands;
using Pos.Product.WebApi.Application.EventHandlers;
using Pos.Product.WebApi.Application.Queries;
using Pos.Product.WebApi.Mapping;
using Pos.Customer.WebApi.Application.EventHandlers;
using Pos.Customer.WebApi.Application.Commands;
using Pos.Product.WebApi.Application.Commands.ProductCategories;
using Pos.Product.Domain.ProductAggregate.Contracts;
using Pos.Customer.WebApi.Application.Queries;

namespace Pos.Product.WebApi
{
    public static class ApplicationBootsraper
    {
        public static IServiceCollection InitBootsraper(this IServiceCollection services, IConfiguration Configuration)
        {
            //Init DermayonBootsraper
            services.InitDermayonBootsraper()
                   // Set Kafka Configuration
                   .InitKafka()
                       .Configure<KafkaEventConsumerConfiguration>(Configuration.GetSection("KafkaConsumer"))
                       .Configure<KafkaEventProducerConfiguration>(Configuration.GetSection("KafkaProducer"))
                        // Product Event
                        .RegisterKafkaConsumer<ProductCreatedEvent, ProductCreateEventHandler>()
                        .RegisterKafkaConsumer<ProductUpdatedEvent, ProductUpdateEventHandler>()
                        .RegisterKafkaConsumer<ProductDeletedEvent, ProductDeleteEventHandler>()
                        // ProductCategory Event
                        .RegisterKafkaConsumer<ProductCategoryCreatedEvent, ProductCategoryCreateEventHandler>()
                        .RegisterKafkaConsumer<ProductCategoryUpdatedEvent, ProductCategoryUpdateEventHandler>()
                        .RegisterKafkaConsumer<ProductCategoryDeletedEvent, ProductCategoryDeleteEventHandler>()
                   .RegisterMongo()
                   // Implement CQRS Event Sourcing =>  [Commands]
                   .RegisterEventSources()
                       .RegisterMongoContext<POSProductEventContext, POSProductEventContextSetting>
                            (Configuration.GetSection("ConnectionStrings:PRODUCT_COMMAND_CONNECTION")
                           .Get<POSProductEventContextSetting>())
                  // Implement CQRS Event Sourcing => UserContext [Query] &                    
                  .RegisterEf()
                    .AddDbContext<POSProductContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("PRODUCT_READ_CONNECTION")))
                .AddOpenApiDocument();                       

            return services;
        }

        public static IServiceCollection InitMapperProfile(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CommandToEventMapperProfile());
                cfg.AddProfile(new DomainToCommandMapperProfile());
                cfg.AddProfile(new EventToDomainMapperProfile());
                
            });            
            services.AddSingleton(provider => mapperConfig.CreateMapper());

            return services;
        }

        public static IServiceCollection InitAppServices(this IServiceCollection services)
        {
            #region Command
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            #endregion            
            #region Queries
            services.AddScoped<IProductQueries, ProductQueries>();
            services.AddScoped<IProductCategoryQueries, ProductCategoryQueries>();
            #endregion
            return services;
        }

        public static IServiceCollection InitEventHandlers(this IServiceCollection services)
        {
            #region Product Commands
            services.AddTransient<ICommandHandler<CreateProductCommand>, CreateProductCommandHandler>();
            services.AddTransient<ProductCreateEventHandler>();

            services.AddTransient<ICommandHandler<UpdateProductCommand>, UpdateProductCommandHandler>();
            services.AddTransient<ProductUpdateEventHandler>();

            services.AddTransient<ICommandHandler<DeleteProductCommand>, DeleteProductCommandHandler>();
            services.AddTransient<ProductDeleteEventHandler>();
            #endregion

            #region Product Category Commands
            services.AddTransient<ICommandHandler<CreateProductCategoryCommand>, CreateProductCategoryCommandHandler>();
            services.AddTransient<ProductCategoryCreateEventHandler>();

            services.AddTransient<ICommandHandler<UpdateProductCategoryCommand>, UpdateProductCategoryCommandHandler>();
            services.AddTransient<ProductCategoryUpdateEventHandler>();

            services.AddTransient<ICommandHandler<DeleteProductCategoryCommand>, DeleteProductCategoryCommandHandler>();
            services.AddTransient<ProductCategoryDeleteEventHandler>();
            #endregion

            return services;
        }
    }
}
