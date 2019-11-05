using AutoMapper;
using Dermayon.Common.Domain;
using Dermayon.Infrastructure.EvenMessaging.Kafka;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pos.Customer.Domain.CustomerAggregate;
using Pos.Customer.Infrastructure;
using Pos.Customer.Infrastructure.EventSources;
using Pos.Customer.Infrastructure.Repositories;
using Pos.Customer.WebApi.Application.Commands;
using Pos.Customer.WebApi.Application.EventHandlers;
using Pos.Customer.WebApi.Application.EventHandlers.SagaPattern;
using Pos.Customer.WebApi.Application.Queries;
using Pos.Customer.WebApi.Mapping;
using Pos.Event.Contracts;

namespace Pos.Customer.WebApi
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
                        .RegisterKafkaConsumer<CustomerCreatedEvent, CustomerCreateEventHandler>()
                        .RegisterKafkaConsumer<CustomerUpdatedEvent, CustomerUpdateEventHandler>()
                        .RegisterKafkaConsumer<CustomerDeletedEvent, CustomerDeleteEventHandler>()
                        //implement choreography saga 
                        .RegisterKafkaConsumer<OrderCreatedEvent, OrderCreatedEventHandler>()
                   .RegisterMongo()
                   // Implement CQRS Event Sourcing => UserContextEvents [Commands]
                   .RegisterEventSources()
                       .RegisterMongoContext<POSCustomerEventContext, POSCustomerEventContextSetting>
                            (Configuration.GetSection("ConnectionStrings:CUSTOMER_COMMAND_CONNECTION")
                           .Get<POSCustomerEventContextSetting>())
                  // Implement CQRS Event Sourcing => UserContext [Query] &                    
                  .RegisterEf()
                    .AddDbContext<POSCustomerContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("CUSTOMER_READ_CONNECTION")))
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
            services.AddScoped<ICustomerRepository, CustomeRepository>();
            #endregion
            #region Queries
            services.AddScoped<ICustomerQueries, CustomerQueries>();
            #endregion
            return services;
        }

        public static IServiceCollection InitEventHandlers(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<CreateCustomerCommand>, CreateCustomerCommandHandler>();
            services.AddTransient<CustomerCreateEventHandler>();

            services.AddTransient<ICommandHandler<UpdateCustomerCommand>, UpdateCustomerCommandHandler>();
            services.AddTransient<CustomerUpdateEventHandler>();

            services.AddTransient<ICommandHandler<DeleteCustomerCommand>, DeleteCustomerCommandHandler>();
            services.AddTransient<CustomerDeleteEventHandler>();

            //implement choreography saga 
            services.AddTransient<OrderCreatedEventHandler>();
            return services;
        }
    }
}
