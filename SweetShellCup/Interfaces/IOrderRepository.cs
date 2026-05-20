using SweetShellCup.Models;

namespace SweetShellCup.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetByUserIdAsync(int userId);
        Task<Order?> GetByIdAsync(int orderId);
        Task<Order> CreateOrderAsync(int userId, string shippingAddress, List<CartItem> cartItems);
    }
}
