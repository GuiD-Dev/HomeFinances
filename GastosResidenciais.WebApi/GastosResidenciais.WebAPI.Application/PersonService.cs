using GastosResidenciais.WebApi.API.DTOs;
using GastosResidenciais.WebApi.API.Interfaces;
using GastosResidenciais.WebApi.Application.Interfaces;
using GastosResidenciais.WebApi.Domain.Entities;

namespace GastosResidenciais.WebApi.Application.Services;

public class PersonService(IPersonRepository personRepository) : IPersonService
{
    public IEnumerable<PersonDto> ListPeople()
    {
        return personRepository.GetMany().Select(person => (PersonDto)person);
    }

    public Person GetPerson(int id)
    {
        return personRepository.GetOneById(id);
    }

    public PersonDto InsertPerson(PersonDto dto)
    {
        personRepository.Insert((Person)dto);
        return dto;
    }

    public bool DeletePerson(int id)
    {
        return personRepository.Delete(id);
    }
}