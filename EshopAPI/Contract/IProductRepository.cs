using EshopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopAPI.Contract
{
   public interface IProductRepository
   {
        //IEnumerable<Product> GetAll();
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> AddAsync(Product product);
        Task<Product> FindAsync(int id);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(int id);
        Task<bool> IsExistedAsync(int id);
   }
}
