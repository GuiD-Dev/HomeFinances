using GastosResidenciais.WebApi.Application.Interfaces;
using GastosResidenciais.WebApi.Domain.Entities;
using GastosResidenciais.WebApi.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GastosResidenciais.WebApi.Infra.Repositories;

public class PersonRepository(PgSqlDbContext context) : IPersonRepository
{
    public IEnumerable<Person> GetMany()
    {
        return context.People.Include(p => p.Transactions).ToList();
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

    public bool Delete(int id)
    {
        var person = GetOneById(id);
        if (person is null) throw new Exception("Id not found");

        context.People.Remove(person);
        context.SaveChanges();

        return true;
    }
}
