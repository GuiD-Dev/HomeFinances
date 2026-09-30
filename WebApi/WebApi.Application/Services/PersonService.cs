using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Application.Interfaces;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Services;

public class PersonService(IPersonRepository personRepository) : IPersonService
{
    public async Task<IEnumerable<PersonDto>> ListPeopleAsync()
    {
        return (await personRepository.GetManyAsync())
            .Select(person => (PersonDto)person);
    }

    public async Task<IEnumerable<PersonDto>> ListPeopleWithTransactionsAsync()
    {
        return (await personRepository.GetManyAsync(includeTransactions: true))
            .Select(person => (PersonDto)person);
    }

    public async Task<Person> GetPersonAsync(int id)
    {
        return await personRepository.GetOneByIdAsync(id);
    }

    public async Task<PersonDto> InsertPersonAsync(PersonDto dto)
    {
        return (PersonDto)await personRepository.InsertAsync((Person)dto);
    }

    public async Task<PersonDto> UpdatePersonAsync(PersonDto dto)
    {
        var person = await personRepository.GetOneByIdAsync(dto.Id, asNoTracking: true, includeTransactions: true);
        if (person is null) throw new Exception("Id not found");

        person.Update((Person)dto);

        await personRepository.UpdateAsync(person);
        return dto;
    }

    public async Task<bool> DeletePersonAsync(int id)
    {
        return await personRepository.DeleteAsync(id);
    }
}