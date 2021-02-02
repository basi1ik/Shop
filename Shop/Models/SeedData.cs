using Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Models
{
    public static class SeedData
    {
        public static  void Initailize(IServiceProvider serviceProvider)
        {
            using (var context = new ShopContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ShopContext>>()))
            {
                if (context.Product.Any())
                {
                    return;
                }

                context.Product.AddRange(
                  
                    new Product                     
                    { 
                        Name = "Apple",
                        Price = 1000M,
                        Balance = 400
                    },

                    new Product
                    {
                        Name = "Milk",
                        Price = 1000M,
                        Balance = 300
                    },

                    new Product
                    {
                        Name = "Bread",
                        Price = 2000M,
                        Balance = 330
                    }
                );

                context.SaveChanges();
            }     
        }
    }
}
