using Microsoft.Extensions.DependencyInjection;
using Pos.Customer.Domain.CustomerAggregate;
using Pos.Customer.Infrastructure;
using System;
using System.IO;
using System.Linq;

namespace Pos.Customer.WebApi.SeedingData
{
    public static class DbSeeder
    {
        public static void Up(IServiceProvider serviceProvider)
        {          
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<POSCustomerContext>();

                if (!context.Customer.Any())
                {
                    for (int i = 0; i < 100; i++)
                    {
                        context.Customer.Add(new MstCustomer { Address = Path.GetRandomFileName().Replace(".", ""), Name = Path.GetRandomFileName().Replace(".", ""), Phone = Path.GetRandomFileName().Replace(".", ""), CreatedBy ="System" });                        
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
