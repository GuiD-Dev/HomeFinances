using AutoMapper;
using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Application.Interfaces;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Services;

public class PersonService(IPersonRepository personRepository, IMapper mapper) : IPersonService
{
    public async Task<IEnumerable<PersonDto>> ListPeopleAsync()
    {
        var people = await personRepository.GetManyAsync();
        return mapper.Map<IEnumerable<PersonDto>>(people);
    }

    public async Task<IEnumerable<PersonDto>> ListPeopleWithTransactionsAsync()
    {
        var people = await personRepository.GetManyAsync(includeTransactions: true);
        return mapper.Map<IEnumerable<PersonDto>>(people);
    }

    public async Task<PersonDto> GetPersonAsync(int id)
    {
        var person = await personRepository.GetOneByIdAsync(id, includeTransactions: true);
        return mapper.Map<PersonDto>(person);
    }

    public async Task<PersonDto> InsertPersonAsync(PersonDto dto)
    {
        var person = mapper.Map<Person>(dto);
        await personRepository.InsertAsync(person);
        return mapper.Map<PersonDto>(person);
    }

    public async Task<PersonDto> UpdatePersonAsync(PersonDto dto)
    {
        var person = await personRepository.GetOneByIdAsync(dto.Id, asNoTracking: true, includeTransactions: true);
        if (person is null) throw new Exception("Id not found");

        person.Update(mapper.Map<Person>(dto));

        await personRepository.UpdateAsync(person);
        return mapper.Map<PersonDto>(person);
    }

    public async Task<bool> DeletePersonAsync(int id)
    {
        return await personRepository.DeleteAsync(id);
    }
}