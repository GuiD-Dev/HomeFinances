using HomeFinances.WebApi.Application.Interfaces;
using HomeFinances.WebApi.Domain.Entities;
using HomeFinances.WebApi.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HomeFinances.WebApi.Infrastructure.Repositories;

public class PersonRepository(PgSqlDbContext context) : IPersonRepository
{
    public async Task<IEnumerable<Person>> GetManyAsync(bool includeTransactions = false)
    {
        var query = context.People.AsQueryable();
        if (includeTransactions) query = query.Include(p => p.Transactions);
        return await query.ToListAsync();
    }

    public async Task<Person> GetOneByIdAsync(int id, bool asNoTracking = false, bool includeTransactions = false)
    {
        var query = context.People.AsQueryable();
        if (asNoTracking) query = query.AsNoTracking();
        if (includeTransactions) query = query.Include(p => p.Transactions);
        return await query.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Person> InsertAsync(Person person)
    {
        context.People.Add(person);
        await context.SaveChangesAsync();
        return person;
    }

    public async Task<Person> UpdateAsync(Person person)
    {
        context.People.Update(person);
        await context.SaveChangesAsync();
        return person;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var person = await GetOneByIdAsync(id);
        if (person is null) throw new Exception("Id not found");

        context.People.Remove(person);
        await context.SaveChangesAsync();

        return true;
    }
}
