using SweetShellCup.Models;

namespace SweetShellCup.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
