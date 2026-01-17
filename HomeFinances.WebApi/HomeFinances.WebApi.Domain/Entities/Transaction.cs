using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeFinances.WebApi.Domain.Enums;
using HomeFinances.WebApi.Domain.Exceptions;

namespace HomeFinances.WebApi.Domain.Entities;

[Table("transaction")]
public class Transaction : BaseEntity
{
  [Column("description"), Required]
  public string Description { get; private set; }

  [Column("value"), Required]
  public decimal Value { get; private set; }

  [Column("type"), Required]
  public TransactionType Type { get; private set; }

  [Column("category"), Required]
  public Category Category { get; private set; }

  [Column("person"), Required]
  public Person Person { get; private set; }

  public Transaction(string description, decimal value, TransactionType type)
  {
    DomainException.ThrowsWhen([
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
    DomainException.ThrowsWhen([
      (
        (category.Purpose == CategoryPurpose.Recipe && Type == TransactionType.Expense)
        ||
        (category.Purpose == CategoryPurpose.Expense && Type == TransactionType.Recipe),
        "Transaction Type and Category are incompatible"
      ),
    ]);

    Category = category;
  }

  public void SetPerson(Person person)
  {
    DomainException.ThrowsWhen([
      (person.Age < 18 && Category.Purpose == CategoryPurpose.Recipe, "Transaction as Recipe cannot be associated to a person under 18 years old"),
    ]);

    Person = person;
  }
}
