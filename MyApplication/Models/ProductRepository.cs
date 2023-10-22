using System.Xml.Linq;

namespace MyApplication.Models
{
    public class ProductRepository
    {
        private List<Product> _products = new List<Product>();

       
        public List<Product> GetAll()
        {
            return _products;
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Remove(int id)
        {
            var productToRemove = _products.FirstOrDefault(p => p.Id == id);
            if (productToRemove != null)
            {
                _products.Remove(productToRemove);
            }
        }
        public void Update(Product product)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == product.Id);
            if(hasProduct != null)
            {
                hasProduct.Price = product.Price;
                hasProduct.Stock = product.Stock;
                hasProduct.Name = product.Name;

                var index = _products.FindIndex(x => x.Id == product.Id);
                _products[index] = hasProduct;
            }
        }
    }

}

