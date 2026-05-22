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
                .Include(o => o.Payments)
                    .ThenInclude(p => p.PaymentMethod)
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
                .Include(o => o.Payments)
                    .ThenInclude(p => p.PaymentMethod)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<Order> CreateOrderAsync(int userId, string shippingAddress, List<CartItem> cartItems, int paymentMethodId)
        {
            // Seed payment methods if none exist
            if (!await _context.PaymentMethods.AnyAsync())
            {
                _context.PaymentMethods.AddRange(
                    new PaymentMethod { MethodName = "COD", Description = "Thanh toán khi nhận hàng", IsActive = true },
                    new PaymentMethod { MethodName = "Bank Transfer", Description = "Chuyển khoản ngân hàng", IsActive = true }
                );
                await _context.SaveChangesAsync();
            }

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

            // Create Payment record
            var payment = new Payment
            {
                OrderId = order.OrderId,
                PaymentMethodId = paymentMethodId,
                PaymentStatus = paymentMethodId == 1 ? "Pending" : "Unpaid",
                TransactionCode = "SSC" + DateTime.Now.ToString("yyMMdd") + new Random().Next(1000, 9999).ToString(),
                PaidAt = null
            };
            _context.Payments.Add(payment);

            // Remove cart items after order
            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.Payments)
                    .ThenInclude(p => p.PaymentMethod)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task UpdateOrderStatusAsync(int orderId, string status, string? shippingAddress = null)
        {
            var order = await _context.Orders
                .Include(o => o.Payments)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order != null)
            {
                order.Status = status;

                if (!string.IsNullOrEmpty(shippingAddress))
                {
                    order.ShippingAddress = shippingAddress;
                }

                // Automatically update payment status to Paid if order status is Completed
                if (status == "Completed")
                {
                    foreach (var payment in order.Payments)
                    {
                        if (payment.PaymentStatus != "Paid")
                        {
                            payment.PaymentStatus = "Paid";
                            payment.PaidAt = DateTime.Now;
                        }
                    }
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
