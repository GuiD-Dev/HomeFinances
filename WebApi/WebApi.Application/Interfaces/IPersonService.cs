using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Interfaces;

public interface IPersonService
{
    Task<IEnumerable<PersonDto>> ListPeopleAsync();
    Task<IEnumerable<PersonDto>> ListPeopleWithTransactionsAsync();
    Task<Person> GetPersonAsync(int id);
    Task<PersonDto> InsertPersonAsync(PersonDto dto);
    Task<PersonDto> UpdatePersonAsync(PersonDto dto);
    Task<bool> DeletePersonAsync(int id);
}