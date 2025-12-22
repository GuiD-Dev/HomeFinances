using GastosResidenciais.WebApi.API.DTOs;
using GastosResidenciais.WebApi.Domain.Entities;

namespace GastosResidenciais.WebApi.API.Interfaces;

public interface ITransactionService
{
    IEnumerable<TransactionDto> ListTransactions();
    Transaction GetTransaction(int id);
    TransactionDto InsertTransaction(TransactionDto dto);
    bool DeleteTransaction(int id);
}