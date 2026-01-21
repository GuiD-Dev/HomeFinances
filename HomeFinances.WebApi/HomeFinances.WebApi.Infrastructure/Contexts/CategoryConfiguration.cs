using HomeFinances.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeFinances.WebApi.Infrastructure.Contexts;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
  public void Configure(EntityTypeBuilder<Category> builder)
  {
    builder.ToTable("category")
      .HasKey(c => c.Id);
    builder.Property(c => c.Description)
      .HasColumnName("description")
      .HasColumnType("varchar(50)")
      .IsRequired();
    builder.Property(c => c.Purpose)
      .HasColumnName("purpose")
      .HasColumnType("smallint")
      .IsRequired();
  }
}
