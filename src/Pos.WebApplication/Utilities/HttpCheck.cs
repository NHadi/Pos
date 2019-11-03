using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pos.WebApplication.Utilities
{
    public class HttpCheck : IHttpCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(url);

                    if (!response.IsSuccessStatusCode)
                        throw new Exception("Url not responding with 200 OK");
                }
                catch (Exception)
                {
                    return await Task.FromResult(HealthCheckResult.Unhealthy("Fail"));
                }
            }
            return await Task.FromResult(HealthCheckResult.Healthy("Connected"));
        }
    }
}
