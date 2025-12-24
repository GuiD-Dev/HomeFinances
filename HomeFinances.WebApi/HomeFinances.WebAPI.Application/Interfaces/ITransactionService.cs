using HomeFinances.WebApi.Application.DTOs;
using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Interfaces;

public interface ITransactionService
{
    IEnumerable<TransactionDto> ListTransactions();
    Transaction GetTransaction(int id);
    TransactionDto InsertTransaction(TransactionDto dto);
    bool DeleteTransaction(int id);
}