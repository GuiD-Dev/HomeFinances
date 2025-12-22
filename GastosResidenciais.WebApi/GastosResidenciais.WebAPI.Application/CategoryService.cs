using GastosResidenciais.WebApi.API.DTOs;
using GastosResidenciais.WebApi.API.Interfaces;
using GastosResidenciais.WebApi.Application.Interfaces;
using GastosResidenciais.WebApi.Domain.Entities;

namespace GastosResidenciais.WebApi.Application.Services;

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