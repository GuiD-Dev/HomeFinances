using HomeFinances.WebApi.Domain.Enums;

namespace HomeFinances.WebApi.Application.DTOs;

public class TransactionRequestDto
{
    public string Description { get; set; }
    public decimal Value { get; set; }
    public TransactionType Type { get; set; }
    public int CategoryId { get; set; }
    public int PersonId { get; set; }
}
