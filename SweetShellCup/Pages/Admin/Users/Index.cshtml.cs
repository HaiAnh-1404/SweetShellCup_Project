using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetShellCup.Pages.Admin.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public IndexModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<User> UsersList { get; set; } = default!;

        public async Task OnGetAsync()
        {
            UsersList = await _userRepository.GetAllUsersAsync();
        }
    }
}
