using System.Threading.Tasks;
using SimpleCleanArch.Domain.Entities;

namespace SimpleCleanArch.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategoryWithBooksAsync(int id);
        Task<Category> GetCategoryBySlugAsync(string slug);
    }
} 