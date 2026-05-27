using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;
using System.Linq;

namespace SweetShellCup.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _userRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;

        public int TotalUsers { get; set; }
        public int TotalOrders { get; set; }
        public int TotalProducts { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal CompletedRevenue { get; set; }

        public List<Order> RecentOrders { get; set; } = new();
        public List<User> RecentUsers { get; set; } = new();

        public IndexModel(
            IUserRepository userRepo,
            IOrderRepository orderRepo,
            IProductRepository productRepo)
        {
            _userRepo = userRepo;
            _orderRepo = orderRepo;
            _productRepo = productRepo;
        }

        public async Task OnGetAsync()
        {
            ViewData["Title"] = "Dashboard";

            var allUsers = await _userRepo.GetAllUsersAsync();
            var allOrders = (await _orderRepo.GetAllOrdersAsync()).ToList();
            var allProducts = (await _productRepo.GetAllAsync()).ToList();

            TotalUsers = allUsers.Count;
            TotalOrders = allOrders.Count;
            TotalProducts = allProducts.Count;

            // Total revenue of all orders except Cancelled
            TotalRevenue = allOrders
                .Where(o => o.Status != "Cancelled")
                .Sum(o => o.TotalAmount);

            // Completed revenue (only orders marked as Completed)
            CompletedRevenue = allOrders
                .Where(o => o.Status == "Completed")
                .Sum(o => o.TotalAmount);

            // Fetch recent 5 orders
            RecentOrders = allOrders
                .OrderByDescending(o => o.OrderDate)
                .Take(5)
                .ToList();

            // Fetch recent 5 users
            RecentUsers = allUsers
                .OrderByDescending(u => u.CreatedAt ?? DateTime.MinValue)
                .Take(5)
                .ToList();
        }
    }
}
