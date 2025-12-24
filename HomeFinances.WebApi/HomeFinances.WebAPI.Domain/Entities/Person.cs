using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeFinances.WebApi.Domain.Enums;

namespace HomeFinances.WebApi.Domain.Entities;

[Table("person")]
public class Person : BaseEntity
{
    [Column("name"), Required]
    public string Name
    {
        get;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Name cannot be empty");

            field = value;
        }
    }

    [Column("age"), Required]
    public int Age
    {
        get;
        set
        {
            if (value < 0)
                throw new Exception("Age cannot lower than 0");

            field = value;
        }
    }

    public virtual ICollection<Transaction> Transactions { get; set; }

    public decimal Recipes => Transactions?.Where(t => t.Type == TransactionType.Recipe)?.Sum(t => t.Value) ?? 0m;
    public decimal Expenses => Transactions?.Where(t => t.Type == TransactionType.Expense)?.Sum(t => t.Value) ?? 0m;
    public decimal Balance => Recipes - Expenses;
}
