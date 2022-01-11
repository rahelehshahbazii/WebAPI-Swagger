using EshopAPI.Contract;
using EshopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopAPI.Repositories
{
    public class SalesPersonsRepository : ISalesPersonsRepository
    {
        public Task<SalesPersons> AddAsync(SalesPersons sales)
        {
            throw new NotImplementedException();
        }

        public Task<SalesPersons> FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SalesPersons>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SalesPersons> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SalesPersons> UpdateAsync(SalesPersons sales)
        {
            throw new NotImplementedException();
        }
    }
}
