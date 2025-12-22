using GastosResidenciais.WebApi.API.DTOs;
using GastosResidenciais.WebApi.Domain.Entities;

namespace GastosResidenciais.WebApi.API.Interfaces;

public interface ICategoryService
{
    IEnumerable<CategoryDto> ListCategories();
    Category GetCategory(int id);
    CategoryDto InsertCategory(CategoryDto dto);
    bool DeleteCategory(int id);
}