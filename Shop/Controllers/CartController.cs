using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        public static HttpContext context; 

        public ActionResult Index()
        {
            var cart = HttpContext.Session.Get<List<Item>>("cart");
            if (cart != null)
            {
                var total = cart.Sum(item => item.Product.Price * item.Quantity);
                ViewBag.Cart = cart;
                ViewBag.Total = total;
            }
       
            return View();
        }

        public ActionResult AddToCart( int id)
        {  
            ProductModel productModel = new ProductModel();

            if (!HttpContext.Session.Keys.Contains("cart"))
            {
                List<Item> cart = new List<Item>();
   
                cart.Add(new Item { Product = productModel.Find(id), Quantity = 1 });
                Console.WriteLine(cart.Last().Product.Name);

                HttpContext.Session.Set<List<Item>>("cart", cart);
            }

            else
            {    
                List<Item> cart = HttpContext.Session.Get<List<Item>>("cart");
                int index = IsExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = productModel.Find(id), Quantity = 1 });
                }                
                HttpContext.Session.Set<List<Item>>("cart", cart);
            }
            return RedirectToAction("Index");    
        }

        public ActionResult Remove(int id)
        {
            List<Item> cart = HttpContext.Session.Get<List<Item>>("cart");
            int index = IsExist(id);
            cart.RemoveAt(index);
            HttpContext.Session.Set<List<Item>>("cart", cart);
           
            return RedirectToAction("Index");
        }

        private int IsExist(int id)
        {
            List<Item> cart = HttpContext.Session.Get<List<Item>>("cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        public ContentResult GetCount()
        {         
            List<Item> cart = HttpContext.Session.Get<List<Item>>("cart");
            if (!cart.Equals(null))
                return Content("0");
            return Content($"{cart.Count}");
        }
    }
}
