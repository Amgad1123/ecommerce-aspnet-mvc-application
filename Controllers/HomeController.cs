using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_store.Data;
using Online_store.Models;
using System.Diagnostics;

namespace Online_store.Controllers
{
    public class HomeController : Controller
    {
        //Remove Logger???
        //private readonly ILogger<HomeController> _logger;
        private readonly OnlineStoreContext _context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(OnlineStoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var featuredProducts = _context.Products
                .Where(p => p.QuantityInStock > 200)
                .Select(p => new ProductModel
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price
                })
                .ToList();

            return View(featuredProducts);
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Verify()
        {
            return View();
        }

        public IActionResult Sale()
        {
            return View("Sale");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
