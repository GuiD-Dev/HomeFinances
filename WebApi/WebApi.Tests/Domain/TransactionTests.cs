using FluentAssertions;
using HomeFinances.WebApi.Domain.Entities;
using HomeFinances.WebApi.Domain.Enums;
using HomeFinances.WebApi.Domain.Exceptions;

namespace HomeFinances.WebApi.Tests.Domain;

public class TransactionTests
{
  [Fact]
  public void Should_Create_Valid_Transaction()
  {
    // Arrange
    var description = "Salary";
    var value = 1000m;
    var type = TransactionType.Income;

    // Act
    var transaction = new Transaction(description, value, type);

    // Assert
    transaction.Should().NotBeNull();
    transaction.Description.Should().Be(description);
    transaction.Value.Should().Be(value);
    transaction.Type.Should().Be(type);
  }

  [Theory]
  [InlineData("", 1000.00, TransactionType.Income, "Description cannot be empty")]
  [InlineData("Salary", 0.0, TransactionType.Income, "Value must be greater than 0")]
  [InlineData("Salary", -1000.00, TransactionType.Income, "Value must be greater than 0")]
  public void Should_Throw_When_Creating_Invalid_Transaction(string description, decimal value, TransactionType type, string expectedMessage)
  {
    var exception = Assert.Throws<DomainException>(() => new Transaction(description, value, type));
    exception.Message.Should().Contain(expectedMessage);
  }
}
