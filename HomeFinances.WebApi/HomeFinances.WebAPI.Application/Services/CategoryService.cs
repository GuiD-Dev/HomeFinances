using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Application.Interfaces;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public IEnumerable<CategoryDto> ListCategories()
    {
        return categoryRepository.GetMany().Select(category => (CategoryDto)category);
    }

    public Category GetCategory(int id)
    {
        return categoryRepository.GetOneById(id);
    }

    public CategoryDto InsertCategory(CategoryDto dto)
    {
        categoryRepository.Insert((Category)dto);
        return dto;
    }

    public bool DeleteCategory(int id)
    {
        return categoryRepository.Delete(id);
    }
}