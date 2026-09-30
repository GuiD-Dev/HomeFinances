using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Application.Interfaces;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<IEnumerable<CategoryDto>> ListCategoriesAsync()
    {
        return (await categoryRepository.GetManyAsync())
            .Select(category => (CategoryDto)category);
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
        return await categoryRepository.GetOneByIdAsync(id);
    }

    public async Task<CategoryDto> InsertCategoryAsync(CategoryDto dto)
    {
        await categoryRepository.InsertAsync((Category)dto);
        return dto;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        return await categoryRepository.DeleteAsync(id);
    }
}