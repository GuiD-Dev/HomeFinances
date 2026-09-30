using HomeFinances.WebApi.Application.Interfaces;
using HomeFinances.WebApi.Domain.Entities;
using HomeFinances.WebApi.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HomeFinances.WebApi.Infrastructure.Repositories;

public class TransactionRepository(PgSqlDbContext context) : ITransactionRepository
{
    public async Task<IEnumerable<Transaction>> GetManyAsync()
    {
        return await context.Transactions
                        .Include(t => t.Person)
                        .Include(t => t.Category)
                        .ToListAsync();
    }

    public async Task<Transaction> GetOneByIdAsync(int id, bool asNoTracking = false)
    {
        var query = context.Transactions.AsQueryable();
        if (asNoTracking) query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Transaction> InsertAsync(Transaction transaction)
    {
        context.Transactions.Add(transaction);
        await context.SaveChangesAsync();
        return transaction;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var transaction = await GetOneByIdAsync(id);
        if (transaction is null) throw new Exception("Id not found");

        context.Transactions.Remove(transaction);
        await context.SaveChangesAsync();

        return true;
    }
}
