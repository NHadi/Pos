using AutoMapper;
using Dermayon.Common.Domain;
using Dermayon.Infrastructure.EvenMessaging.Kafka;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pos.Order.Infrastructure;
using Pos.Order.Infrastructure.Repositories;
using Pos.Order.WebApi.Application.Commands;
using Pos.Event.Contracts;
using Pos.Order.Domain.OrderAggregate.Contract;
using Pos.Customer.WebApi.Application.Queries;
using Pos.Order.WebApi.Mapping;
using Pos.Order.WebApi.Application.EventHandlers;
using Pos.Order.Infrastructure.EventSources;
using Pos.Event.Contracts.order;

namespace Pos.Order.WebApi
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
                        .RegisterKafkaConsumer<OrderShippedEvent, OrderShippedEventHandler>()
                        .RegisterKafkaConsumer<OrderCancelledEvent, OrderCanceledEventHandler>()
                   .RegisterMongo()
                   // Implement CQRS Event Sourcing => UserContextEvents [Commands]
                   .RegisterEventSources()
                       .RegisterMongoContext<POSOrderEventContext, POSOrderEventContextSetting>
                            (Configuration.GetSection("ConnectionStrings:ORDER_COMMAND_CONNECTION")
                           .Get<POSOrderEventContextSetting>())
                  // Implement CQRS Event Sourcing => UserContext [Query] &                    
                  .RegisterEf()
                    .AddDbContext<POSOrderContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("ORDER_READ_CONNECTION")))
                .AddOpenApiDocument();                       

            return services;
        }

        public static IServiceCollection InitMapperProfile(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CommandToEventMapperProfile());
                cfg.AddProfile(new DomainToCommandMapperProfile());
                cfg.AddProfile(new EventoDomainMapperProfile());                
            });            
            services.AddSingleton(provider => mapperConfig.CreateMapper());

            return services;
        }

        public static IServiceCollection InitAppServices(this IServiceCollection services)
        {
            #region Command
            services.AddScoped<IOrderRepository, OrderRepository>();
            #endregion
            #region Queries
            services.AddScoped<IOrderQueries, OrderQueries>();
            #endregion
            return services;
        }

        public static IServiceCollection InitEventHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<CreateOrderCommand>, CreateOrderCommandHandler>();
            services.AddTransient<OrderShippedEventHandler>();
            services.AddTransient<OrderCanceledEventHandler>();
            return services;
        }
    }
}
