using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ProductModel productModel = new ProductModel();
            ViewBag.products = productModel.FindAll();
            return View();
        }
    }
}
