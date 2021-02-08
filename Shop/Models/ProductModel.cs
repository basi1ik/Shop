using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ProductModel
    {
        private List<Product> products;

        public ProductModel()
        {
            products = new List<Product>()
            {
               new Product
                    {
                        Id = 1,
                        Name = "Apple",
                        Price = 1000M,
                        Balance = 400
                    },

                    new Product
                    {
                        Id = 2,
                        Name = "Milk",
                        Price = 1000M,
                        Balance = 300
                    },

                    new Product
                    {
                        Id = 3,
                        Name = "Bread",
                        Price = 2000M,
                        Balance = 330
                    }
            };
        }

        public List<Product> FindAll()
        {
            return this.products;
        }

        public Product Find(int id)
        {
             var prod = products.Where(p => p.Id == id).First();
            return prod;
         
            //return products.Single(p => p.Id.Equals(id));
           // return "id =" + id + "Count=" + products.Count;
          //  return products.Where(p => p.Id.Equals(id)).First();
        }
    }
    
}
