using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Online_store.Data;
using Online_store.Models;

namespace Online_store.Controllers
{
    public class CheckoutController : Controller

    {
        private readonly OnlineStoreContext _context;
        public CheckoutController(OnlineStoreContext context)
        {
            _context = context;
        }

        // GET: /Checkout/Index
        public IActionResult Index()
        { 
            return View();
        }


        // GET: /Checkout/ThankYou
        public IActionResult ThankYou()
        {
            ClearCart();
            return View();
        }

        public IActionResult ClearCart()
        {
            var ProductsInCart = _context.Products.Where(p => p.NumInCart > 0).ToList();

            foreach (var product in ProductsInCart)
            {
                product.NumInCart = 0;

            }
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
