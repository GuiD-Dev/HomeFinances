using HomeFinances.WebApi.Domain.Entities;
using HomeFinances.WebApi.Domain.Enums;

namespace HomeFinances.WebApi.Application.DTOs;

public class TransactionDto
{
  public int Id { get; set; }
  public string Description { get; set; }
  public decimal Value { get; set; }
  public TransactionType Type { get; set; }
  public int CategoryId { get; set; }
  public string CategoryDescription { get; set; }
  public int PersonId { get; set; }
  public string PersonName { get; set; }
}