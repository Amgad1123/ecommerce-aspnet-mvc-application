using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Online_store.Models;
using Online_store.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


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
            if (TempData.ContainsKey("FilteredProducts"))
            {
                // This was a pain in the arse, was trying to pass in an argument forever, but eventually just 
                // serialized them using this json class thing and deserialized them when needed
                var filteredProductsJson = TempData["FilteredProducts"] as string;
                var filteredProducts = Deserialize<List<ProductModel>>(filteredProductsJson);
                TempData.Remove("FilteredProducts");
                return View(filteredProducts);
            }
            else
            {
                // Defaults to all products (for when you initially load up the page)
                var allProducts = _context.Products.ToList();
                return View(allProducts);
            }
        }



        // retrieve all products from the database as json
        public IActionResult Retrieve()
        {
            List<ProductModel> products = _context.Products.ToList();
            return Json(products);
        }

        //retrieve a specific product by id from the database
        public ProductModel GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public IActionResult Details(int id)
        {
            var product = GetProductById(id);
            if (product == null)
            {
                return NotFound(); 
            }

            return View(product);
        }

        // This one is linked to the search bar, it searches the DB using LIKE, and returns the results as a list to the index, which then 
        // displays the narrowed-down results
        public IActionResult Search(string input)
        {
            var filteredProducts = _context.Products
                .Where(p => EF.Functions.Like(p.Name, $"%{input}%") || EF.Functions.Like(p.Description, $"%{input}%"))
                .ToList();

            TempData["FilteredProducts"] = Serialize(filteredProducts);

            return RedirectToAction("Index", "Products");
        }

        // Found these two on stackoverflow lol
        private string Serialize(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        private T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }




    }
}