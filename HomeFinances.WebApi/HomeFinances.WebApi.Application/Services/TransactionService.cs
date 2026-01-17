using AutoMapper;
using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Application.Interfaces;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Services;

public class TransactionService(
    IPersonRepository personRepository, ICategoryRepository categoryRepository, ITransactionRepository transactionRepository, IMapper mapper
) : ITransactionService
{
  public async Task<IEnumerable<TransactionDto>> ListTransactionsAsync()
  {
    var transactions = await transactionRepository.GetManyAsync();
    return mapper.Map<IEnumerable<TransactionDto>>(transactions);
  }

  public async Task<TransactionDto> GetTransactionAsync(int id)
  {
    var transaction = await transactionRepository.GetOneByIdAsync(id);
    return mapper.Map<TransactionDto>(transaction);
  }

  public async Task<TransactionDto> InsertTransactionAsync(TransactionRequestDto dto)
  {
    var category = await categoryRepository.GetOneByIdAsync(dto.CategoryId);
    if (category is null)
      throw new Exception("Category not found");

    var person = await personRepository.GetOneByIdAsync(dto.PersonId);
    if (person is null)
      throw new Exception("Person not found");

    var transaction = mapper.Map<Transaction>(dto);
    transaction.SetCategory(category);
    transaction.SetPerson(person);

    await transactionRepository.InsertAsync(transaction);

    return mapper.Map<TransactionDto>(transaction);
  }

  public async Task<bool> DeleteTransactionAsync(int id)
  {
    return await transactionRepository.DeleteAsync(id);
  }
}