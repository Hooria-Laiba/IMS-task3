using IMSIdentity.Models.Interfaces;
using IMSIdentity.Models;
using Microsoft.Data.SqlClient;
using IMSIdentity.Models.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace IMSIdentity.Models.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly MyAppDBContext _dbcontext;

        public ProductRepository(MyAppDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public List<Product> GetAll()
        {
            return _dbcontext.Products.ToList();
        }
        public Product GetById(int id)
        {
            return _dbcontext.Products.FirstOrDefault(p => p.id == id);
        }
        public void Add(Product product)
        {
            _dbcontext.Products.Add(product);
            _dbcontext.SaveChanges();
        }

        public void Update(Product product)
        {
            var existing = _dbcontext.Products.FirstOrDefault(p => p.Barcode == product.Barcode);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Brand = product.Brand;
                existing.Quantity = product.Quantity;
                existing.Price = product.Price;
                existing.Type = product.Type;
                existing.Expiry = product.Expiry;
                existing.Description = product.Description;

                _dbcontext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var product = _dbcontext.Products.Find(id);
            if (product != null)
            {
                _dbcontext.Products.Remove(product);
                _dbcontext.SaveChanges();
            }
        }

    }
}


