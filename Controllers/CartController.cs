using Microsoft.AspNetCore.Mvc;
using Online_store.Models;
using Online_store.Data;

namespace Online_store.Controllers
{
    public class CartController : Controller
    {
        private readonly OnlineStoreContext _context;

        public CartController(OnlineStoreContext context)
        {
            _context = context;
        }

        // Adding an Item to the cart
        public IActionResult AddToCart(int productId, int quantity)
        {
            return RedirectToAction("Index", "Cart"); // Redirect to the cart page
        }

        // Removing an Item
        public IActionResult RemoveFromCart(int productId)
        {
            return RedirectToAction("Index", "Cart"); 
        }

        public IActionResult Index()
        {
            return View(); // Return the cart view
        }
    }
}
