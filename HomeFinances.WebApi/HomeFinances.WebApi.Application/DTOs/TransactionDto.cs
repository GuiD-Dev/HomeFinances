using HomeFinances.WebApi.Domain.Entities;
using HomeFinances.WebApi.Domain.Enums;

namespace HomeFinances.WebApi.Application.DTOs;

public class TransactionDto
{
    public string Description { get; set; }
    public decimal Value { get; set; }
    public TransactionType Type { get; set; }
    public int CategoryId { get; set; }
    public string CategoryDescription { get; set; }
    public int PersonId { get; set; }
    public string PersonName { get; set; }

    public static explicit operator Transaction(TransactionDto dto)
    {
        return new Transaction
        {
            Description = dto.Description,
            Value = dto.Value,
            Type = dto.Type,
        };
    }

    public static explicit operator TransactionDto(Transaction entity)
    {
        return new TransactionDto
        {
            Description = entity.Description,
            Value = entity.Value,
            Type = entity.Type,
            CategoryId = entity.Category.Id,
            CategoryDescription = entity.Category.Description,
            PersonId = entity.Person.Id,
            PersonName = entity.Person.Name,
        };
    }
}