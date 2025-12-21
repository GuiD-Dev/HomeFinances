using GastosResidenciais.WebApi.Application.Interfaces;
using GastosResidenciais.WebApi.Domain.Entities;
using GastosResidenciais.WebApi.Infra.Contexts;

namespace GastosResidenciais.WebApi.Infra.Repositories;

public class PersonRepository(PgSqlDbContext context) : IPersonRepository
{
    public IEnumerable<Person> GetMany()
    {
        return context.People.ToList();
    }

    public Person GetOne(int id)
    {
        throw new NotImplementedException();
    }

    public Person Insert(Person person)
    {
        context.People.Add(person);
        context.SaveChanges();
        return person;
    }

    public bool Delete(int id)
    {
        var person = context.People.FirstOrDefault(p => p.Id == id);
        if (person is null)
            throw new Exception("Id not found");

        context.People.Remove(person);
        context.SaveChanges();

        return true;
    }
}
