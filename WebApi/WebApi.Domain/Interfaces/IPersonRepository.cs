using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Interfaces;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetManyAsync(bool includeTransactions = false);
    Task<Person> GetOneByIdAsync(int id, bool asNoTracking = false, bool includeTransactions = false);
    Task<Person> InsertAsync(Person person);
    Task<Person> UpdateAsync(Person person);
    Task<bool> DeleteAsync(int id);
}