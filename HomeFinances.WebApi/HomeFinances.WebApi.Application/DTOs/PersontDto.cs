using HomeFinances.WebApi.Domain.Entities;

namespace HomeFinances.WebApi.Application.DTOs;

public class PersonDto
{
  public int Id { get; set; }
  public string Name { get; set; }
  public int Age { get; set; }
  public IEnumerable<TransactionDto> Transactions { get; set; }
  public decimal Incomes { get; set; }
  public decimal Expenses { get; set; }
  public decimal Balance { get; set; }

  public static explicit operator Person(PersonDto dto)
  {
    return new Person(dto.Name, dto.Age)
    {
      Id = dto.Id,
    };
  }

  public static explicit operator PersonDto(Person entity)
  {
    return new PersonDto
    {
      Id = entity.Id,
      Name = entity.Name,
      Age = entity.Age,
      Transactions = entity.Transactions?
        .Select(transaction => new TransactionDto
        {
          Description = transaction.Description,
          Value = transaction.Value,
          Type = transaction.Type,
        }) ?? [],
      Incomes = entity.Incomes,
      Expenses = entity.Expenses,
      Balance = entity.Balance,
    };
  }
}