using EshopAPI.Contract;
using EshopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private EshopApi_DBContext _context;

        public ProductRepository(EshopApi_DBContext context)
        {
            _context = context;
        }
      
        public async Task<Product> AddAsync(Product product)
        {
            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public Task<Product> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistedAsync(int id)
        {
            throw new NotImplementedException();
        }

         public Task<Product> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
