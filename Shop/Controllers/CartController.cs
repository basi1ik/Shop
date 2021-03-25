using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CartController : Controller
    {  
        private readonly ShopContext _context;

        public CartController(ShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetList() {

            return View(await _context.Product.ToListAsync());
        }

        public ActionResult Index()
        {
            var cart = HttpContext.Session.Get<List<Item>>("cart");
            if (cart != null)                
            {
               var total = cart.Sum(item => item.Product.Price * item.Quantity);
                ViewBag.Cart = cart;
                ViewBag.Total = total;
                ViewBag.Payment = QiwiClient.Run(total).ToString();                               
            }
       
            return View();
        }
        [HttpPost]
        public ActionResult AddToCart(int id)
        {  
            ProductModel productModel = new ProductModel();

            if (!HttpContext.Session.Keys.Contains("cart"))
            {
                var prod = _context.Product.Where(p => p.Id == id).First();
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = prod, Quantity = 1 });
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
                    //cart.Add(new Item { Product = productModel.Find(id), Quantity = 1 });
                    var prod = _context.Product.Where(p => p.Id == id).First();
                    cart.Add(new Item { Product = prod, Quantity = 1 });
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

        public ActionResult<int> GetCount()
        {
            int count = 0;
            List<Item> cart = HttpContext.Session.Get<List<Item>>("cart");           

            if(cart != null)
            {
                foreach (var c in cart)
                {
                    count = count + c.Quantity;
                }
                return count;
            }

            return count;
        }
    }
}
