using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.Interfaces;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetManyAsync();
    Task<Transaction> GetOneByIdAsync(int id, bool asNoTracking = false);
    Task<Transaction> InsertAsync(Transaction transaction);
    Task<bool> DeleteAsync(int id);
}