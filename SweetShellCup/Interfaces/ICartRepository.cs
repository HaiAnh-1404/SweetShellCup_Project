using SweetShellCup.Models;

namespace SweetShellCup.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart?> GetCartByUserIdAsync(int userId);
        Task<IEnumerable<CartItem>> GetCartItemsAsync(int cartId);
        Task<IEnumerable<CartItem>> GetByUserIdAsync(int userId);
        Task AddItemAsync(int userId, int productId, int quantity);

        // GIỮ NGUYÊN TÊN METHOD như trong IndexModel đang gọi
        Task RemoveItemAsync(int cartItemId);  // ← Giữ tên này
        Task UpdateQuantityAsync(int cartItemId, int quantity);  // ← Giữ tên này
        Task ClearCartAsync(int userId);
        Task<int> GetCartItemCountAsync(int userId);
    }
}