using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;
using System.Threading.Tasks;
using System.Linq;

namespace SweetShellCup.Pages.Admin.Users
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public EditModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [BindProperty]
        public User EditUser { get; set; } = default!;

        public SelectList RoleOptions { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var user = await _userRepository.GetUserByIdAsync(id.Value);
            if (user == null) return NotFound();

            EditUser = user;
            var roles = await _userRepository.GetAllRolesAsync();
            RoleOptions = new SelectList(roles, "RoleId", "RoleName");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("EditUser.Role");

            if (!ModelState.IsValid)
            {
                var roles = await _userRepository.GetAllRolesAsync();
                RoleOptions = new SelectList(roles, "RoleId", "RoleName");
                return Page();
            }

            var existingUser = await _userRepository.GetUserByIdAsync(EditUser.UserId);
            if (existingUser != null)
            {
                existingUser.FullName = EditUser.FullName;
                existingUser.Email = EditUser.Email;
                existingUser.Phone = EditUser.Phone;
                existingUser.Address = EditUser.Address;
                existingUser.RoleId = EditUser.RoleId;
                
                await _userRepository.UpdateUserAsync(existingUser);
            }

            TempData["Message"] = "Cập nhật tài khoản thành công!";
            return RedirectToPage("./Index");
        }
    }
}
