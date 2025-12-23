using GastosResidenciais.WebApi.Application.Interfaces;
using GastosResidenciais.WebApi.Domain.Entities;
using GastosResidenciais.WebApi.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GastosResidenciais.WebApi.Infra.Repositories;

public class CategoryRepository(PgSqlDbContext context) : ICategoryRepository
{
    public IEnumerable<Category> GetMany()
    {
        return context.Categories.ToList();
    }

    public Category GetOneById(int id, bool asNoTracking = false)
    {
        var query = context.Categories.AsQueryable();
        if (asNoTracking) query = query.AsNoTracking();
        return query.FirstOrDefault(c => c.Id == id);
    }

    public Category Insert(Category category)
    {
        context.Categories.Add(category);
        context.SaveChanges();
        return category;
    }

    public bool Delete(int id)
    {
        var category = GetOneById(id);
        if (category is null) throw new Exception("Id not found");

        context.Categories.Remove(category);
        context.SaveChanges();

        return true;
    }
}
