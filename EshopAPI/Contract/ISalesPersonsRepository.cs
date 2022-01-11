using EshopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopAPI.Contract
{
   public interface ISalesPersonsRepository
    {
        Task<IEnumerable<SalesPersons>> GetAllAsync();
        Task<SalesPersons> AddAsync(SalesPersons sales);
        Task<SalesPersons> FindAsync(int id);
        Task<SalesPersons> UpdateAsync(SalesPersons sales);
        Task<SalesPersons> RemoveAsync(int id);
        Task<bool> IsExistsAsync(int id);
    }
}
