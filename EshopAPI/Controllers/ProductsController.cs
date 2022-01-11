using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EshopAPI.Models;
using EshopAPI.Contract;

namespace EshopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // private readonly EshopApi_DBContext _context;
        //public ProductsController(EshopApi_DBContext context)
        //{
        //    _context = context;
        //}
        private IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = new ObjectResult(await _productRepository.GetAllAsync())
            {
               // StatusCode = (int)HttpStatusCode.OK
            };

            return result;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
         public async Task<ActionResult<Product>> GetProduct(int id)
        {
            //  var product = await _context.Product.FindAsync(id);
            var product = await _productRepository.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            // _context.Entry(product).State = EntityState.Modified;
            await _productRepository.UpdateAsync(product);
            

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            //_context.Product.Add(product);
            //await _context.SaveChangesAsync();

            await _productRepository.AddAsync(product);
            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            //  var product = await _context.Product.FindAsync(id);
            var product = await _productRepository.FindAsync(id);


            if (product == null)
            {
                return NotFound();
            }

            //_context.Product.Remove(product);
            //await _context.SaveChangesAsync();
            await _productRepository.RemoveAsync(id);

            return product;
        }

        private async Task<bool> ProductExists(int id)
        {
            //return _context.Product.Any(e => e.ProductId == id);
           return await _productRepository.IsExistedAsync(id);
        }
    }
}
