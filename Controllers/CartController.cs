using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Online_store.Models;
using System.Linq;
using Online_store.Data;

namespace Online_store.Controllers
{
    public class CartController : Controller
    {
        private readonly OnlineStoreContext _context;
        public List<ProductModel> _boughtItems = new List<ProductModel>();

        public CartController(OnlineStoreContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var ProductsInCart = _context.Products.Where(p => p.NumInCart > 0).ToList();
            var subtotal = CalculateSubtotal(_boughtItems);
            var tax = CalculateTax(subtotal);
            var total = subtotal + tax;

            ViewBag.Subtotal = subtotal;
            ViewBag.Tax = tax;
            ViewBag.Total = total;
            return View(ProductsInCart);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                for (int i = 0; i < quantity; i++)
                {
                    _boughtItems.Add(product);
                }

                // Update product quantities
                product.NumInCart += quantity;
                product.QuantityInStock -= quantity;

                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Products");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                for (int i = 0; i < quantity; i++)
                {
                    _boughtItems.Remove(product);
                }

                // Update product quantities
                product.NumInCart -= quantity;
                product.QuantityInStock += quantity;

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        public static decimal CalculateSubtotal(List<ProductModel> items)
        {
            decimal subtotal = 0;
            foreach (var item in items)
            {
                if (item != null)
                {
                    subtotal += Math.Round(item.Price * item.NumInCart, 2);
                }
            }
            return subtotal;
        }


        public static decimal CalculateTax(decimal subtotal)
        {
            return Math.Round((subtotal * 0.075m), 2);
        }
        public static decimal CalculateGrandTotal(decimal subtotal)
        {
            return subtotal + CalculateTax(subtotal);
        }
    }
}
