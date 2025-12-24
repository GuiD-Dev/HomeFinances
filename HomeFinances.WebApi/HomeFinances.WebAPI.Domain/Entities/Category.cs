using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeFinances.WebApi.Domain.Enums;

namespace HomeFinances.WebApi.Domain.Entities;

[Table("category")]
public class Category
{
    [Column("id"), Key]
    public int Id { get; set; }

    [Column("description"), Required]
    public string Description
    {
        get;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Description cannot be empty");

            field = value;
        }
    }

    [Column("purpose"), Required]
    public CategoryPurpose Purpose
    {
        get;
        set
        {
            if (!Enum.IsDefined(typeof(CategoryPurpose), value))
                throw new ArgumentException("Invalid purpose");

            field = value;
        }
    }
}