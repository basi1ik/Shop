using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Cart
    {
        public List<Item> CartList { get;  private set; }
        public Cart()
        {
            CartList = new List<Item>();
        }

        public void AddToCart( Item item)
        {
            CartList.Add(item);
        }

    }
}
