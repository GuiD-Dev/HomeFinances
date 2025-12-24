using HomeFinances.WebApi.Application.Interfaces;
using HomeFinances.WebApi.Domain.Entities;
using HomeFinances.WebApi.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HomeFinances.WebApi.Infrastructure.Repositories;

public class PersonRepository(PgSqlDbContext context) : IPersonRepository
{
    public IEnumerable<Person> GetMany(bool includeTransactions = false)
    {
        var query = context.People.AsQueryable();
        if (includeTransactions) query = query.Include(p => p.Transactions);
        return query.ToList();
    }

    public Person GetOneById(int id, bool asNoTracking = false)
    {
        var query = context.People.AsQueryable();
        if (asNoTracking) query = query.AsNoTracking();
        return query.FirstOrDefault(p => p.Id == id);
    }

    public Person Insert(Person person)
    {
        context.People.Add(person);
        context.SaveChanges();
        return person;
    }

    public Person Update(Person person)
    {
        if (GetOneById(person.Id, asNoTracking: true) is null)
            throw new Exception("Id not found");

        context.People.Update(person);
        context.SaveChanges();
        return person;
    }

    public bool Delete(int id)
    {
        var person = GetOneById(id);
        if (person is null) throw new Exception("Id not found");

        context.People.Remove(person);
        context.SaveChanges();

        return true;
    }
}
