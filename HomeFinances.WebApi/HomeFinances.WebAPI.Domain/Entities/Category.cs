using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomeFinances.WebApi.Domain.Enums;
using HomeFinances.WebApi.Domain.Exceptions;

namespace HomeFinances.WebApi.Domain.Entities;

[Table("category")]
public class Category : BaseEntity
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

    [Column("purpose"), Required]
    public CategoryPurpose Purpose
    {
        get;
        set
        {
            if (!Enum.IsDefined(typeof(CategoryPurpose), value))
                throw new DomainException("Invalid purpose");

            field = value;
        }
    }
}