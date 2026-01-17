using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Application.Interfaces;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Services;

public class TransactionService(
    IPersonRepository personRepository, ICategoryRepository categoryRepository, ITransactionRepository transactionRepository
) : ITransactionService
{
  public async Task<IEnumerable<TransactionDto>> ListTransactionsAsync()
  {
    return (await transactionRepository.GetManyAsync())
        .Select(transaction => (TransactionDto)transaction);
  }

  public async Task<Transaction> GetTransactionAsync(int id)
  {
    return await transactionRepository.GetOneByIdAsync(id);
  }

  public async Task<TransactionDto> InsertTransactionAsync(TransactionDto dto)
  {
    var category = await categoryRepository.GetOneByIdAsync(dto.CategoryId);
    if (category is null)
      throw new Exception("Category not found");

    var person = await personRepository.GetOneByIdAsync(dto.PersonId);
    if (person is null)
      throw new Exception("Person not found");

    var transaction = (Transaction)dto;
    transaction.SetCategory(category);
    transaction.SetPerson(person);

    return (TransactionDto)await transactionRepository.InsertAsync(transaction);
  }

  public async Task<bool> DeleteTransactionAsync(int id)
  {
    return await transactionRepository.DeleteAsync(id);
  }
}