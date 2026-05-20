using System.Collections.Generic;
using System.Threading.Tasks;
using SweetShellCup.Models;

namespace SweetShellCup.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task<Role?> GetRoleByNameAsync(string roleName);
        Task<List<Role>> GetAllRolesAsync();
    }
}
