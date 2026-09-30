using HomeFinances.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeFinances.WebApi.Infrastructure.Contexts;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
  public void Configure(EntityTypeBuilder<Transaction> builder)
  {
    builder.ToTable("transaction")
      .HasKey(t => t.Id);
    builder.Property(t => t.Description)
      .HasColumnName("description")
      .HasColumnType("varchar(255)")
      .IsRequired();
    builder.Property(t => t.Value)
      .HasColumnName("value")
      .HasColumnType("decimal(18,2)")
      .IsRequired();
    builder.Property(t => t.Type)
      .HasColumnName("type")
      .HasColumnType("smallint")
      .IsRequired();
    builder.Property(t => t.CategoryId)
      .HasColumnName("category_id")
      .HasColumnType("int")
      .IsRequired();
    builder.Property(t => t.PersonId)
      .HasColumnName("person_id")
      .HasColumnType("int")
      .IsRequired();
  }
}
