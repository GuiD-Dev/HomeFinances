using HomeFinances.WebApi.Domain.Enums;
using HomeFinances.WebApi.Domain.Exceptions;

namespace HomeFinances.WebApi.Domain.Entities;

public class Category : BaseEntity
{
	public string Description { get; private set; }
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