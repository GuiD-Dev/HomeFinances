using GastosResidenciais.WebApi.API.DTOs;
using GastosResidenciais.WebApi.Domain.Entities;

namespace GastosResidenciais.WebApi.API.Interfaces;

public interface IPersonService
{
    IEnumerable<PersonDto> ListPeople();
    Person GetPerson(int id);
    PersonDto InsertPerson(PersonDto dto);
    PersonDto UpdatePerson(PersonDto dto);
    bool DeletePerson(int id);
}