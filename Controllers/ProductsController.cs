using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Data;
using ProductManagement.Entities;
using System.Net;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            return await _context.products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.products
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        [HttpPost]
        public async void PostProduct(Product product)
        {
            _context.products.Add(product);
            await _context.SaveChangesAsync();
        }

        [HttpPut("{id}")]
        public async void PutProduct(int id)
        {
            var findproduct = await GetProductByIdAsync(id);

            _context.products.Update(findproduct);
            await _context.SaveChangesAsync();
           
        }

        [HttpDelete("{id}")]
        public async void deleteProduct(int id)
        {
            var findproduct = await GetProductByIdAsync(id);

            _context.products.Remove(findproduct);
            await _context.SaveChangesAsync();

        }
    }
}
