using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;

namespace SweetShellCup.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SweetShellCupDbContext _context;

        public UserRepository(SweetShellCupDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email)) return null;
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            // Sử dụng SQL thuần để xóa sạch dữ liệu liên quan ở các bảng có ràng buộc khóa ngoại (kể cả bảng không khai báo trong DbContext)
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM cartitems WHERE CartId IN (SELECT CartId FROM cart WHERE UserId = {0})", id);
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM cart WHERE UserId = {0}", id);
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM reviews WHERE UserId = {0}", id);
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM useraddresses WHERE UserId = {0}", id);
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM wishlists WHERE UserId = {0}", id);
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM shipments WHERE OrderId IN (SELECT OrderId FROM orders WHERE UserId = {0})", id);
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM payments WHERE OrderId IN (SELECT OrderId FROM orders WHERE UserId = {0})", id);
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM orderdetails WHERE OrderId IN (SELECT OrderId FROM orders WHERE UserId = {0})", id);
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM orders WHERE UserId = {0}", id);
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM users WHERE UserId = {0}", id);
        }

        public async Task<Role?> GetRoleByNameAsync(string roleName)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == roleName);
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
