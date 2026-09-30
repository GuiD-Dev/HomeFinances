using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetManyAsync();
    Task<Category> GetOneByIdAsync(int id, bool asNoTracking = false);
    Task<Category> InsertAsync(Category category);
    Task<bool> DeleteAsync(int id);
}