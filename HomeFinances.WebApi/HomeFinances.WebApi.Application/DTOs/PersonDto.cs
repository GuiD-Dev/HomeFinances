using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.DTOs;

public class PersonDto
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int Age { get; set; }
  public IEnumerable<TransactionDto> Transactions { get; set; }
  public decimal Recipes { get; set; }
  public decimal Expenses { get; set; }
  public decimal Balance { get; set; }
}