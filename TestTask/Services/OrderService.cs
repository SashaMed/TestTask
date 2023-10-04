using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class OrderService : IOrderService
    {

        private const int thresholdQuantity = 10;
        private ApplicationDbContext applicationDbContext;

        public OrderService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<Order> GetOrder()
        {
            var order = await applicationDbContext.Orders.OrderByDescending(o => o.Price * o.Quantity) .FirstOrDefaultAsync(); 
            return order;
        }

        public async Task<List<Order>> GetOrders()
        {
            var orders = await applicationDbContext.Orders.Where(c => c.Quantity > thresholdQuantity).ToListAsync();
            return orders;
        }
    }
}
