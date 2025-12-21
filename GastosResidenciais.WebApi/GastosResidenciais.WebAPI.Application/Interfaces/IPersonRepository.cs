using GastosResidenciais.WebApi.Domain.Entities;

namespace GastosResidenciais.WebApi.Application.Interfaces;

public interface IPersonRepository
{
    IEnumerable<Person> GetMany();
    Person GetOneById(int id);
    Person Insert(Person person);
    bool Delete(int id);
}