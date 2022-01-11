using EshopAPI.Contract;
using EshopAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private EshopApi_DBContext _context;
        private IMemoryCache _cache;

        public CustomerRepository(EshopApi_DBContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task<Customer> AddAsync(Customer customer)
        {
            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> FindAsync(int id)
        {
            var cacheCustomer = _cache.Get<Customer>(id);
            if(cacheCustomer !=null)
            {
                return cacheCustomer;           
            }
            else
            {
                var customer = await _context.Customer.Include(c => c.Orders).SingleOrDefaultAsync(c => c.CustomerId == id);
                var cacheoption = new MemoryCacheEntryOptions()
               .SetSlidingExpiration(TimeSpan.FromSeconds(60));
                _cache.Set(customer.CustomerId, customer, cacheoption);
                return customer;
            }
        }
            
         public IEnumerable<Customer> GetAll()
        {
            return _context.Customer.ToList();
        }
        public async Task<bool> IsExistedAsync(int id)
        {
            return await _context.Customer.AnyAsync(c => c.CustomerId == id);
        }
        public async Task<Customer> Remove(int id)
        {
            var customer = await _context.Customer.SingleAsync(c => c.CustomerId == id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> UpdateAsync(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
         public async Task<int> CountCustomer()
        {
            return await _context.Customer.CountAsync();
        }
      
    }
}
