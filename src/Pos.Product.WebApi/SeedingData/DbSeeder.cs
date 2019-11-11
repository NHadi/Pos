using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Pos.Product.Domain.ProductAggregate;
using Pos.Product.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.Product.WebApi.SeedingData
{
    public static class DbSeeder
    {
        public static void Up(IServiceProvider serviceProvider)
        {          
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<POSProductContext>();

                if (!context.ProductCategory.Any())
                {
                    context.ProductCategory.Add(new ProductCategory { Id = new Guid("009341c9-01e7-4f25-aa14-eb31dd8367ee"), Name = "Gold" });
                    context.ProductCategory.Add(new ProductCategory { Id = new Guid("57f826db-87de-4194-b30e-ca648b8733c2"), Name = "Silver" });
                    context.ProductCategory.Add(new ProductCategory { Id = new Guid("b8dbdbf9-1bb9-4505-8e58-a5b3482a759b"), Name = "Platinum" });
                    context.ProductCategory.Add(new ProductCategory { Id = new Guid("67063dc4-5d2f-42a4-b0c4-8ee406e9f9f3"), Name = "Bronze" });
                    context.SaveChanges();
                }

                if (!context.Product.Any())
                {
                    for (int i = 0; i < 100; i++)
                    {
                        context.Product.Add(new MstProduct { Category = new Guid("009341c9-01e7-4f25-aa14-eb31dd8367ee"), Name = $"Oil Gold A-{i}", PartNumber = $"G-0{i}", Quantity = i * 3, UnitPrice = i * 100});
                        context.Product.Add(new MstProduct { Category = new Guid("57f826db-87de-4194-b30e-ca648b8733c2"), Name = $"Oil Silver A-{i}", PartNumber = $"S-0{i}", Quantity = i * 3, UnitPrice = i * 100 });
                        context.Product.Add(new MstProduct { Category = new Guid("b8dbdbf9-1bb9-4505-8e58-a5b3482a759b"), Name = $"Oil Platinum A-{i}", PartNumber = $"S-0{i}", Quantity = i * 3, UnitPrice = i * 100 });
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
