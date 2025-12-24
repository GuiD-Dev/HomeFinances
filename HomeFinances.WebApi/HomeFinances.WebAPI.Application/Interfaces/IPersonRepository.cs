using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Interfaces;

public interface IPersonRepository
{
    IEnumerable<Person> GetMany(bool includeTransactions = false);
    Person GetOneById(int id, bool asNoTracking = false);
    Person Insert(Person person);
    Person Update(Person person);
    bool Delete(int id);
}