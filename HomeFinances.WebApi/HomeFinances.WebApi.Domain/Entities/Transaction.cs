using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeFinances.WebApi.Domain.Enums;
using HomeFinances.WebApi.Domain.Exceptions;

namespace HomeFinances.WebApi.Domain.Entities;

[Table("transaction")]
public class Transaction : BaseEntity
{
    [Column("description"), Required]
    public string Description
    {
        get;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Description cannot be empty");

            field = value;
        }
    }

    [Column("value"), Required]
    public decimal Value
    {
        get;
        set
        {
            if (value <= 0)
                throw new DomainException("Value must be greater than 0");

            field = value;
        }
    }


    [Column("type"), Required]
    public TransactionType Type
    {
        get;
        set
        {
            if (!Enum.IsDefined(typeof(TransactionType), value))
                throw new DomainException("Invalid Transaction Type");

            field = value;
        }
    }

    [Column("category"), Required]
    public Category Category
    {
        get;
        set
        {
            if (
                value.Purpose == CategoryPurpose.Recipe && Type == TransactionType.Expense
                ||
                value.Purpose == CategoryPurpose.Expense && Type == TransactionType.Recipe
            )
            {
                throw new DomainException("Transaction Type and Category are incompatible");
            }

            field = value;
        }
    }

    [Column("person"), Required]
    public Person Person
    {
        get;
        set
        {
            if (value.Age < 18 && Category.Purpose == CategoryPurpose.Recipe)
                throw new DomainException("Transaction as Recipe cannot be associated to a person under 18 years old");

            field = value;
        }
    }
}
