using GastosResidenciais.WebApi.API.DTOs;
using GastosResidenciais.WebApi.API.Interfaces;
using GastosResidenciais.WebApi.Application.Interfaces;
using GastosResidenciais.WebApi.Domain.Entities;

namespace GastosResidenciais.WebApi.Application.Services;

public class PersonService(IPersonRepository personRepository) : IPersonService
{
    public IEnumerable<Person> ListPeople()
    {
        return personRepository.GetMany();
    }

    public Person GetPerson(int id)
    {
        return personRepository.GetOne(id);
    }

    public Person InsertPerson(PersonDto dto)
    {
        var person = new Person(dto.Name, dto.Age);
        return personRepository.Insert(person);
    }

    public bool DeletePerson(int id)
    {
        return personRepository.Delete(id);
    }
}