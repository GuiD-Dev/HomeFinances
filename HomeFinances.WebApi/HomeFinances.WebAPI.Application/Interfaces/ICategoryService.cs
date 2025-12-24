using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Interfaces;

public interface ICategoryService
{
    IEnumerable<CategoryDto> ListCategories();
    Category GetCategory(int id);
    CategoryDto InsertCategory(CategoryDto dto);
    bool DeleteCategory(int id);
}