using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pos.WebApplication.HealthChecks;
using Pos.WebApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.WebApplication
{
    public static class ApplicationBootsraper
    {
        public static IServiceCollection InitBootsraper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IHttpCheck, HttpCheck>();
            return services;
        }

        public static IServiceCollection SetHealtCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
               .AddCheck<OrderServicesHc>("Order HTTP Check")
               .AddCheck<ProductServicesHc>("Product HTTP Check")
               .AddCheck<CustomerServicesHc>("Customer HTTP Check")
               .AddCheck<ReportServicesHc>("Report HTTP Check")
            ;

            return services;
        }
    }
}
