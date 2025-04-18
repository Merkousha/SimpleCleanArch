using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleCleanArch.Application.DTOs;

namespace SimpleCleanArch.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<CategoryDto> GetCategoryBySlugAsync(string slug);
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto);
        Task UpdateCategoryAsync(int id, CategoryUpdateDto categoryUpdateDto);
        Task DeleteCategoryAsync(int id);
    }
} 