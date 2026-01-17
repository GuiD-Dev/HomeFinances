using HomeFinances.WebApi.Domain.Entities;
using HomeFinances.WebApi.Domain.Enums;

namespace HomeFinances.WebApi.Application.DTOs;

public class CategoryDto
{
  public int Id { get; set; }
  public string Description { get; set; }
  public CategoryPurpose Purpose { get; set; }

  public static explicit operator Category(CategoryDto dto)
  {
    return new Category(dto.Description, dto.Purpose)
    {
      Id = dto.Id,
    };
  }

  public static explicit operator CategoryDto(Category entity)
  {
    return new CategoryDto
    {
      Id = entity.Id,
      Description = entity.Description,
      Purpose = entity.Purpose,
    };
  }
}