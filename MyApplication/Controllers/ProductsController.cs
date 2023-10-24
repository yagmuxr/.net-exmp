using Microsoft.AspNetCore.Mvc;
using MyApplication.Helpers;
using MyApplication.Models;

namespace MyApplication.Controllers
{

    public class ProductsController : Controller
    {
        private AppDbContext _context;
        private ProductRepository productRepository;
        private IHelper _helper;

        public ProductsController(AppDbContext context, IHelper helper)
        {
            productRepository = new ProductRepository();

            _context = context;
            _helper = helper;

            //if (!_context.Products.Any())
            //{
            //    _context.Products.Add(new Product()
            //    {
            //        Name = "Kalem",
            //        Price = 100,
            //        Stock = 150,
            //        Color = "Red",
                    
            //    });
            //    _context.Products.Add(new Product()
            //    {
            //        Name = "Silgi",
            //        Price = 50,
            //        Stock = 100,
            //        Color = "Pink",
                    
            //    });
            //    _context.Products.Add(new Product()
            //    {
            //        Name = "Defter",
            //        Price = 200,
            //        Stock = 150,
            //        Color = "Green",
                    
            //    });
            //    _context.SaveChanges();
            //}
        }
        public IActionResult Index()
        {


            var products = _context.Products.ToList();
            return View(products);
        }

       
        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id); //primary key'e göre arama yapar !
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product updateProduct, int productId)
        {
            updateProduct.Id = productId;
                _context.Products.Update(updateProduct);
                _context.SaveChanges();
            TempData["status"] = "Başarıyla güncellendi"; //cookie üzerinden taşır!
            return RedirectToAction("Index");
            
        }


        public IActionResult Add()
        {
            return View();
        }
        [HttpPost] //Requestin body kısmında gönderilir post ile!
        public IActionResult SaveProduct(Product newProduct)
        {
            //1.Yöntem : 
            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price = decimal.Parse(HttpContext.Request.Form["Price"]);
            //var stock = int.Parse(HttpContext.Request.Form["Stock"]);
            //var color = HttpContext.Request.Form["Color"].ToString();

            //2.Yöntem
            //Product newProduct = new Product() { Name = Name, Price = Price, Stock = Stock, Color = Color };
            _context.Products.Add(newProduct);
            
            _context.SaveChanges();
            TempData["status"] = "Başarıyla eklendi";
            return RedirectToAction("Index");
        }

        //[HttpGet] //get ile URL'de gözükür bilgiler
        //public IActionResult SaveProduct(Product newProduct)
        //{
        //    //1. Yöntem : 
        //    //var name = HttpContext.Request.Form["Name"].ToString();
        //    //var price = decimal.Parse(HttpContext.Request.Form["Price"]);
        //    //var stock = int.Parse(HttpContext.Request.Form["Stock"]);
        //    //var color = HttpContext.Request.Form["Color"].ToString();

        //    //2. Yöntem
        //    //Product newProduct = new Product() { Name = Name, Price = Price, Stock= Stock , Color = Color };
        //    _context.Products.Add(newProduct);
        //    _context.SaveChanges();
        //    return View();
        //}

    }

}
