using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeFinances.WebApi.Domain.Enums;
using HomeFinances.WebApi.Domain.Exceptions;

namespace HomeFinances.WebApi.Domain.Entities;

[Table("category")]
public class Category : BaseEntity
{
	[Column("description"), Required]
	public string Description { get; private set; }

	[Column("purpose"), Required]
	public CategoryPurpose Purpose { get; private set; }

	public Category(string description, CategoryPurpose purpose)
	{
		DomainException.ThrowsWhen([
			(string.IsNullOrWhiteSpace(description), "Description cannot be empty"),
			(!Enum.IsDefined(typeof(CategoryPurpose), purpose), "Invalid purpose"),
		]);

		Description = description;
		Purpose = purpose;
	}
}