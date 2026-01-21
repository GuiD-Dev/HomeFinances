using HomeFinances.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeFinances.WebApi.Infrastructure.Contexts;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
  public void Configure(EntityTypeBuilder<Person> builder)
  {
    builder.ToTable("person")
      .HasKey(p => p.Id);
    builder.Property(p => p.Name)
      .HasColumnName("name")
      .HasColumnType("varchar(50)")
      .IsRequired();
    builder.Property(p => p.Age)
      .HasColumnName("age")
      .HasColumnType("smallint")
      .IsRequired();
  }
}
