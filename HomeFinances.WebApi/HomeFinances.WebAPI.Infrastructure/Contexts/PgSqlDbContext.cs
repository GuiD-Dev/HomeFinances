using HomeFinances.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeFinances.WebApi.Infrastructure.Contexts;

public class PgSqlDbContext(DbContextOptions<PgSqlDbContext> options) : DbContext(options)
{
    public DbSet<Person> People { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}
