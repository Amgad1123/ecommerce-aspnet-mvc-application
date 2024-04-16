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
        public IActionResult Details(int? id, string searchString)
        {
            IQueryable<ProductModel> products = _context.Products;

            // Filter products based on search string
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
            }

            // Filter by product ID if provided
            if (id.HasValue)
            {
                products = products.Where(p => p.ProductId == id);
            }

            // Retrieve the list of products
            List<ProductModel> productList = products.ToList();

            // Check if any products match the search criteria
            if (productList.Count == 0)
            {
                return NotFound();
            }

            // Return the list of products as JSON
            return Json(productList);
        }

    }
}
