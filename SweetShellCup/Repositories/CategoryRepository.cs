using Microsoft.EntityFrameworkCore;
using SweetShellCup.Interfaces;
using SweetShellCup.Models;

namespace SweetShellCup.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SweetShellCupDbContext _context;

        public CategoryRepository(SweetShellCupDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
