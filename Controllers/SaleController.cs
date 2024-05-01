using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Online_store.Models;
using Online_store.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static Online_store.Models.ProductModel;

namespace Online_store.Controllers
{
    public class SaleController : Controller
    {
        private readonly OnlineStoreContext _context;
        public string SaleID { get; set; }
            

        public SaleController(OnlineStoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            var sale = _context.Sales.ToList();
            for (int i = 0; i < sale.Count; i++)
            {
                for(int j = 0; j < products.Count; j++)
                {
                    if (sale[i].ProductID == products[j].ProductId)
                    {
                        sale[i].Price = (products[j].Price - (products[j].Price * sale[i].SalesPercentage));
                        sale[i].Name = products[j].Name;
                    }
                }
                
            }
            return View(sale);
        }

        // Action to retrieve all products from the database
        public IActionResult Retrieve()
        {
            List<SaleModel> sale = _context.Sales.ToList();
            return Json(sale);
        }

    
    }
}
