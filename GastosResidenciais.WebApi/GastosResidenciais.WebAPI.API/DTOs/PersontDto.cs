using GastosResidenciais.WebApi.Domain.Entities;

namespace GastosResidenciais.WebApi.API.DTOs;

public class PersonDto
{
    public string Name { get; set; }
    public int Age { get; set; }
    public IEnumerable<TransactionDto> Transactions { get; set; }
    public decimal Recipes { get; set; }
    public decimal Expenses { get; set; }
    public decimal Balance { get; set; }

    public static explicit operator Person(PersonDto dto)
    {
        return new Person
        {
            Name = dto.Name,
            Age = dto.Age,
        };
    }

    public static explicit operator PersonDto(Person entity)
    {
        return new PersonDto
        {
            Name = entity.Name,
            Age = entity.Age,
            Transactions = entity.Transactions
                .Select(transaction => new TransactionDto
                {
                    Description = transaction.Description,
                    Value = transaction.Value,
                    Type = transaction.Type,
                }),
            Recipes = entity.Recipes,
            Expenses = entity.Expenses,
            Balance = entity.Balance,
        };
    }
}