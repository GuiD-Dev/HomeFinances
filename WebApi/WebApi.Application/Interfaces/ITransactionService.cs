using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Interfaces;

public interface ITransactionService
{
    Task<IEnumerable<TransactionDto>> ListTransactionsAsync();
    Task<Transaction> GetTransactionAsync(int id);
    Task<TransactionDto> InsertTransactionAsync(TransactionDto dto);
    Task<bool> DeleteTransactionAsync(int id);
}