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
        private List<CartItem> _boughtItems = new List<CartItem>();

        public CartController(OnlineStoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var subtotal = CalculateSubtotal(_boughtItems);
            var tax = CalculateTax(subtotal);
            var total = subtotal + tax;

            ViewBag.Subtotal = subtotal;
            ViewBag.Tax = tax;
            ViewBag.Total = total;


            return View(_boughtItems);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                _boughtItems.Add(new CartItem { ProductId = productId, Quantity = quantity });
                //This action requires a button in the style of  <button type="submit">Add to Cart</button> on each item page

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            var cartItemToRemove = _boughtItems.FirstOrDefault(item => item.ProductId == productId);
            if (cartItemToRemove != null)
            {
                _boughtItems.Remove(cartItemToRemove);
            }

            return RedirectToAction("Index");
        }

        private decimal CalculateSubtotal(List<CartItem> items)
        {
            decimal subtotal = 0;
            foreach (var item in items)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == item.ProductId);
                if (product != null)
                {
                    subtotal += product.Price * item.Quantity;
                }
            }
            return subtotal;
        }

        private decimal CalculateTax(decimal subtotal)
        {
            return subtotal * 0.075m;
        }
        private decimal CalculateGrandTotal(decimal subtotal)
        {
            return subtotal * 1.075m;
        }
    }
}
