using GastosResidenciais.WebApi.API.DTOs;
using GastosResidenciais.WebApi.Domain.Entities;

namespace GastosResidenciais.WebApi.API.Interfaces;

public interface IPersonService
{
    IEnumerable<Person> ListPeople();
    Person GetPerson(int id);
    Person InsertPerson(PersonDto dto);
    bool DeletePerson(int id);
}