using Microsoft.Extensions.DependencyInjection;
using Pos.Order.Domain;
using Pos.Order.Infrastructure;
using System;
using System.IO;
using System.Linq;

namespace Pos.Order.WebApi.SeedingData
{
    public static class DbSeeder
    {
        public static void Up(IServiceProvider serviceProvider)
        {          
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<POSOrderContext>();

                if (!context.Order.Any())
                {
                    for (int i = 0; i < 100; i++)
                    {
                      
                        context.Order.Add(new MstOrder { OrderDate = DateTime.Now, OrderNumber = $"O-{i}", 
                            ShipAddress= Path.GetRandomFileName().Replace(".", ""),
                            ShipCity = Path.GetRandomFileName().Replace(".", ""),
                            ShipCountry = Path.GetRandomFileName().Replace(".", ""),
                            ShipName = Path.GetRandomFileName().Replace(".", ""),
                            ShipPostalCode = Path.GetRandomFileName().Replace(".", ""),
                            Status = i % 2 == 1 ? "Delivered" : "Canceled",
                            Amount = i * 40,
                        });                        
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
