using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Online_store.Models;
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

        // Action to retrieve all products from the database
        public IActionResult Retrieve()
        {
            List<ProductModel> products = _context.Products.ToList();
            return Json(products);
        }

        // Action to retrieve a specific product by id from the database
        public ProductModel GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public IActionResult Details(int id)
        {
            var product = GetProductById(id);
            if (product == null)
            {
                return NotFound();  // Handle product not found scenario
            }

            return View(product);  // Return the retrieved product object
        }


    }
}