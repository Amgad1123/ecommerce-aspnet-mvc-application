using Microsoft.AspNetCore.Mvc;
using Online_store.Data;
using System.Linq;

namespace Online_store.Controllers
{
    public class ProductsController : Controller
    {
        private readonly OnlineStoreContext _context;

        public ProductsController(OnlineStoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
    }
}
