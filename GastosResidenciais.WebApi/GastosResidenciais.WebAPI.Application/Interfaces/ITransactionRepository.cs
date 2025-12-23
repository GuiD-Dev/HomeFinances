using GastosResidenciais.WebApi.Domain.Entities;

namespace GastosResidenciais.WebApi.Application.Interfaces;

public interface ITransactionRepository
{
    IEnumerable<Transaction> GetMany();
    Transaction GetOneById(int id, bool asNoTracking = false);
    Transaction Insert(Transaction transaction);
    bool Delete(int id);
}