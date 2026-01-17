using AutoMapper;
using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Application.Interfaces;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Services;

public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
{
    public async Task<IEnumerable<CategoryDto>> ListCategoriesAsync()
    {
        var categories = await categoryRepository.GetManyAsync();
        return mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetCategoryAsync(int id)
    {
        var category = await categoryRepository.GetOneByIdAsync(id);
        return mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> InsertCategoryAsync(CategoryDto dto)
    {
        var category = mapper.Map<Category>(dto);
        await categoryRepository.InsertAsync(category);
        return mapper.Map<CategoryDto>(category);
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        return await categoryRepository.DeleteAsync(id);
    }
}