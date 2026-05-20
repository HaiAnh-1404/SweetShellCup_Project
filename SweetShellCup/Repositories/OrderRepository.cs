using Microsoft.EntityFrameworkCore;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;

namespace SweetShellCup.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SweetShellCupDbContext _context;

        public OrderRepository(SweetShellCupDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetByUserIdAsync(int userId)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<Order> CreateOrderAsync(int userId, string shippingAddress, List<CartItem> cartItems)
        {
            var totalAmount = cartItems.Sum(ci => ci.Quantity * ci.Product!.Price);

            var order = new Order
            {
                UserId = userId,
                ShippingAddress = shippingAddress,
                TotalAmount = totalAmount,
                Status = "Pending",
                OrderDate = DateTime.Now
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach (var item in cartItems)
            {
                _context.OrderDetails.Add(new OrderDetail
                {
                    OrderId = order.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.Product!.Price
                });
            }

            // Remove cart items after order
            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}
