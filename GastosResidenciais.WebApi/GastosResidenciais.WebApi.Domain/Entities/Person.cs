using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GastosResidenciais.WebApi.Domain.Entities;

[Table("person")]
public class Person
{
    [Column("id"), Key]
    public int Id { get; set; }

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
}
