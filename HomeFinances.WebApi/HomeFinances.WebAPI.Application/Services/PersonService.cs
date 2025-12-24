using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Application.Interfaces;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Services;

public class PersonService(IPersonRepository personRepository) : IPersonService
{
    public IEnumerable<PersonDto> ListPeople()
    {
        return personRepository.GetMany()
            .Select(person => (PersonDto)person);
    }

    public IEnumerable<PersonDto> ListPeopleAndTransactions()
    {
        return personRepository.GetMany(includeTransactions: true)
            .Select(person => (PersonDto)person);
    }

    public Person GetPerson(int id)
    {
        return personRepository.GetOneById(id);
    }

    public PersonDto InsertPerson(PersonDto dto)
    {
        return (PersonDto)personRepository.Insert((Person)dto);
    }

    public PersonDto UpdatePerson(PersonDto dto)
    {
        personRepository.Update((Person)dto);
        return dto;
    }

    public bool DeletePerson(int id)
    {
        return personRepository.Delete(id);
    }
}