using HomeFinances.WebApi.Application.Interfaces;
using HomeFinances.WebApi.Domain.Entities;
using HomeFinances.WebApi.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HomeFinances.WebApi.Infrastructure.Repositories;

public class CategoryRepository(PgSqlDbContext context) : ICategoryRepository
{
    public async Task<IEnumerable<Category>> GetManyAsync()
    {
        return await context.Categories.ToListAsync();
    }

    public async Task<Category> GetOneByIdAsync(int id, bool asNoTracking = false)
    {
        var query = context.Categories.AsQueryable();
        if (asNoTracking) query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Category> InsertAsync(Category category)
    {
        context.Categories.Add(category);
        await context.SaveChangesAsync();
        return category;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await GetOneByIdAsync(id);
        if (category is null) throw new Exception("Id not found");

        context.Categories.Remove(category);
        await context.SaveChangesAsync();

        return true;
    }
}
