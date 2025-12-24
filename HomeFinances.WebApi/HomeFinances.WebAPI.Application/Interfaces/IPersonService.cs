using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Interfaces;

public interface IPersonService
{
    IEnumerable<PersonDto> ListPeople();
    IEnumerable<PersonDto> ListPeopleAndTransactions();
    Person GetPerson(int id);
    PersonDto InsertPerson(PersonDto dto);
    PersonDto UpdatePerson(PersonDto dto);
    bool DeletePerson(int id);
}