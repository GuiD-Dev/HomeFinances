using HomeFinances.WebApi.Application.Interfaces;
using HomeFinances.WebApi.Application.Services;
using HomeFinances.WebApi.Infrastructure.Contexts;
using HomeFinances.WebApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeFinances.WebApi.CrossCutting;

public static class DependencyInjection
{
  public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<PgSqlDbContext>(options =>
      options.UseNpgsql(configuration["PgSQlConnection:PgSQlConnectionString"])
    );

    services.AddScoped<IPersonService, PersonService>();
    services.AddScoped<IPersonRepository, PersonRepository>();

    services.AddScoped<ICategoryService, CategoryService>();
    services.AddScoped<ICategoryRepository, CategoryRepository>();

    services.AddScoped<ITransactionService, TransactionService>();
    services.AddScoped<ITransactionRepository, TransactionRepository>();

    return services;
  }
}
