using HomeFinances.WebApi.Domain.Entities;
using HomeFinances.WebApi.Domain.Enums;

namespace HomeFinances.WebApi.Application.DTOs;

public class CategoryDto
{
  public int Id { get; set; }
  public string Description { get; set; }
  public CategoryPurpose Purpose { get; set; }
}