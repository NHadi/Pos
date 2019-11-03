using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.WebApplication.Utilities
{
    public interface IHttpCheck
    {
        Task<HealthCheckResult> CheckHealthAsync(string url);
    }
}
