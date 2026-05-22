using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetShellCup.Pages.Admin.Orders
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        public IndexModel(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> OrdersList { get; set; } = default!;

        public async Task OnGetAsync()
        {
            OrdersList = await _orderRepository.GetAllOrdersAsync();
        }

        public async Task<Microsoft.AspNetCore.Mvc.IActionResult> OnGetNewOrdersCountAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            var count = System.Linq.Enumerable.Count(orders, o => o.Status == "Pending");
            return new Microsoft.AspNetCore.Mvc.JsonResult(new { count });
        }
    }
}
