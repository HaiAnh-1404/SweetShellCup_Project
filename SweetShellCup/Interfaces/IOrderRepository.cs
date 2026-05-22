using SweetShellCup.Models;

namespace SweetShellCup.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetByUserIdAsync(int userId);
        Task<Order?> GetByIdAsync(int orderId);
        Task<Order> CreateOrderAsync(int userId, string shippingAddress, List<CartItem> cartItems, int paymentMethodId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task UpdateOrderStatusAsync(int orderId, string status, string? shippingAddress = null);
    }
}
