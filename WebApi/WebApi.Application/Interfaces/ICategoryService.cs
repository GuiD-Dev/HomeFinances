using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> ListCategoriesAsync();
    Task<Category> GetCategoryAsync(int id);
    Task<CategoryDto> InsertCategoryAsync(CategoryDto dto);
    Task<bool> DeleteCategoryAsync(int id);
}