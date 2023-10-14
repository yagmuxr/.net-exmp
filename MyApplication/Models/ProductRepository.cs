namespace MyApplication.Models
{
    public class ProductRepository
    {
        private List<Product> _products = new List<Product>();

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Remove(int id)
        {
            var productToRemove = GetById(id);
            if (productToRemove != null)
            {
                _products.Remove(productToRemove);
            }
        }
    }

}
