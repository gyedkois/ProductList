using Microsoft.AspNetCore.Mvc;
using ProductListApp.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ProductListApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        // ILogger is injected via constructor for logging
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        // Index action returns a strongly-typed view
        public IActionResult Index()
        {
            _logger.LogInformation("Product Index action accessed. Loading product list.");

            // Create mock data
            var products = new List<Product>
            {
                new Product { Id = 101, Name = "Gaming PC - Entry Level",Price = 899.99m, Description = "Low-End Gaming." },
                new Product { Id = 102, Name = "Gaming PC - Mid Level", Price = 1499.99m, Description = "Mid-End Gaming" },
                new Product { Id = 103, Name = "Gaming PC - Top Tier", Price = 3499.99m, Description = "High-End Gaming" }
            };

            return View(products);
        }

        // Action to handle the form post (simulation of a purchase)
        [HttpPost]
        public IActionResult Buy(int id)
        {
            // Log a warning event for the form submission
            _logger.LogWarning("FORM POST: Attempting to 'purchase' Product ID {ProductId}.", id);
            return RedirectToAction(nameof(Index));
        }
    }
}