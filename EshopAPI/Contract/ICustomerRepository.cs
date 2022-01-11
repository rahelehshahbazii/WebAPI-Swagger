using EshopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopAPI.Contract
{
   public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Task<Customer> AddAsync(Customer customer);
        Task<Customer> FindAsync(int id);
        Task<Customer> UpdateAsync(Customer customer);
        Task<Customer> Remove(int id);
        Task<bool> IsExistedAsync(int id);
        Task<int> CountCustomer();
    }
}
