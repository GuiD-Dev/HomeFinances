using HomeFinances.WebApi.Domain.Enums;
using HomeFinances.WebApi.Domain.Exceptions;

namespace HomeFinances.WebApi.Domain.Entities;

public class Transaction : BaseEntity
{
  public string Description { get; private set; }
  public decimal Value { get; private set; }
  public TransactionType Type { get; private set; }
  public int CategoryId { get; private set; }
  public Category Category { get; private set; }
  public int PersonId { get; private set; }
  public Person Person { get; private set; }

  public Transaction(string description, decimal value, TransactionType type)
  {
    DomainException.ThrowWhen([
      (string.IsNullOrWhiteSpace(description), "Description cannot be empty"),
      (value <= 0, "Value must be greater than 0"),
      (!Enum.IsDefined(typeof(TransactionType), type), "Invalid Transaction Type"),
    ]);

    Description = description;
    Value = value;
    Type = type;
  }

  public void SetCategory(Category category)
  {
    DomainException.ThrowWhen([
      (
        (category.Purpose == CategoryPurpose.Income && Type == TransactionType.Expense)
        ||
        (category.Purpose == CategoryPurpose.Expense && Type == TransactionType.Income),
        "Transaction Type and Category are incompatible"
      ),
    ]);

    Category = category;
  }

  public void SetPerson(Person person)
  {
    DomainException.ThrowWhen([
      (person.Age < 18 && Category.Purpose == CategoryPurpose.Income, "Transaction as Income cannot be associated to a person under 18 years old"),
    ]);

    Person = person;
  }
}
