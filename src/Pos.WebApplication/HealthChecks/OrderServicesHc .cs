using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Pos.WebApplication.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.WebApplication.HealthChecks
{
    public class OrderServicesHc : IHealthCheck
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpCheck _httpCheck;
        public OrderServicesHc(IHttpCheck httpCheck, IConfiguration configuration)
        {
            _httpCheck = httpCheck;
            _configuration = configuration;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = new CancellationToken())
            => await _httpCheck.CheckHealthAsync(_configuration["api:order"] + "values/");
    }
}
