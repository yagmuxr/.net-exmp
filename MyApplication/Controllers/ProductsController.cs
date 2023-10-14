using Microsoft.AspNetCore.Mvc;
using MyApplication.Models;

namespace MyApplication.Controllers
{
    public class ProductsController : Controller
    {
        private ProductRepository productRepository;

        public ProductsController()
        {
            productRepository = new ProductRepository();
            if (!productRepository.GetAll().Any())
            {
                productRepository.Add(new()
                {
                    Id = 1,
                    Name = "Kalem",
                    Stock = 10,
                    Price = 5
                });
                productRepository.Add(new()
                {
                    Id = 2,
                    Name = "Silgi",
                    Stock = 5,
                    Price = 5
                });
                productRepository.Add(new()
                {
                    Id = 3,
                    Name = "Defter",
                    Stock = 10,
                    Price = 20
                });
            }

        }
        public IActionResult Index()
        {
            var products = productRepository.GetAll();
            return View(products);
        }
        public IActionResult Remove(int id)
        {
            productRepository.Remove(id);
            return RedirectToAction("Index");
        }

    }
}
