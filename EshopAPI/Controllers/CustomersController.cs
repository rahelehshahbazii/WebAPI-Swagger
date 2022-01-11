using EshopAPI.Contract;
using EshopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Authorization;

namespace EshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class CustomersController : ControllerBase
    {
        //private EshopApi_DBContext _context;
        //public CustomersController(EshopApi_DBContext context)
        //{
        //    _context = context;
        //}

        private ICustomerRepository _customerRepository;
        
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
           
        }

        [HttpGet]
        //[ResponseCache(Duration=60)]
        public IActionResult GetCustomer()
        {
            // var result = new ObjectResult(_context.Customer)
            var result = new ObjectResult(_customerRepository.GetAll());
            {
              int StatusCode = (int)HttpStatusCode.OK;
            };
            // Request.HttpContext.Response.Headers.Add("X-Count", _context.Customer.Count().ToString());
            Request.HttpContext.Response.Headers.Add("X-Count", _customerRepository.CountCustomer().ToString());
            Request.HttpContext.Response.Headers.Add("X-Name", "Raheleh Shahbazi");
            return result;
        }
       
        /// <summary>
        /// This is a Get Request 
        /// </summary>
        /// <param name="id">This int Gets CustomerId</param>
        /// <returns></returns>
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            if (await CustomerExists(id))
                {
                // var customer = await _context.Customer.SingleOrDefaultAsync(c => c.CustomerId == id);

              


                var customer = await _customerRepository.FindAsync(id);
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("Person", Name ="Person")]
        public IActionResult GetPerson()
        {
            return Content("Person");
        }

        private async Task<bool> CustomerExists(int id)
        {
            // return _context.Customer.Any( c=>c.CustomerId == id);
            return await _customerRepository.IsExistedAsync(id); 
        }
         
        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //_context.Customer.Add(customer);
            //await _context.SaveChangesAsync();
            await _customerRepository.AddAsync(customer);
            
            
            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            //_context.Entry(customer).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
            await _customerRepository.UpdateAsync(customer);
            return Ok(customer);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            //var customer = await _context.Customer.FindAsync(id);
            //_context.Customer.Remove(customer);
            //await _context.SaveChangesAsync();

            await _customerRepository.Remove(id);
            return Ok();
        }

    }
}
