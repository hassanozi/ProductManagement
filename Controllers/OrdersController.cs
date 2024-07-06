using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Data;
using ProductManagement.Entities;

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly StoreContext _context;

        public OrdersController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IReadOnlyList<Order>> GetOrderAsync()
        {
            return await _context.orders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.orders
                .FirstOrDefaultAsync(p => p.OrderId == id);
        }

        [HttpPost]
        public async void PostOrder(Order order)
        {
            _context.orders.Add(order);
            await _context.SaveChangesAsync();
        }

        [HttpPut("{id}")]
        public async void PutOrder(int id)
        {
            var findOrder = await GetOrderByIdAsync(id);

            _context.orders.Update(findOrder);
            await _context.SaveChangesAsync();

        }

        [HttpDelete("{id}")]
        public async void deleteOrder(int id)
        {
            var findOrder = await GetOrderByIdAsync(id);

            _context.orders.Remove(findOrder);
            await _context.SaveChangesAsync();

        }
    }
}
