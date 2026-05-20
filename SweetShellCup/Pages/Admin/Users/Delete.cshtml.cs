using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using System.Threading.Tasks;

namespace SweetShellCup.Pages.Admin.Users
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public DeleteModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var user = await _userRepository.GetUserByIdAsync(id.Value);
            if (user == null) return NotFound();

            await _userRepository.DeleteUserAsync(id.Value);
            TempData["Message"] = "Đã xóa tài khoản thành công!";
            return RedirectToPage("./Index");
        }
    }
}
