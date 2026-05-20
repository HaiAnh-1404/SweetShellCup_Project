using SweetShellCup.Models;

namespace SweetShellCup.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart?> GetCartByUserIdAsync(int userId);
        Task<IEnumerable<CartItem>> GetCartItemsAsync(int cartId);
        Task AddItemAsync(int userId, int productId, int quantity);
        Task UpdateQuantityAsync(int cartItemId, int quantity);
        Task RemoveItemAsync(int cartItemId);
        Task<int> GetCartItemCountAsync(int userId);
    }
}
