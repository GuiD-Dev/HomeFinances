using FluentAssertions;
using HomeFinances.WebApi.Domain.Entities;
using HomeFinances.WebApi.Domain.Enums;
using HomeFinances.WebApi.Domain.Exceptions;

namespace HomeFinances.WebApi.Tests.Domain;

public class CategoryTests
{
  [Fact]
  public void Should_Create_Valid_Category()
  {
    // Arrange
    var description = "Salary";
    var purpose = CategoryPurpose.Income;

    // Act
    var category = new Category(description, purpose);

    // Assert
    category.Should().NotBeNull();
    category.Description.Should().Be(description);
    category.Purpose.Should().Be(purpose);
  }

  [Theory]
  [InlineData("", CategoryPurpose.Income, "Description cannot be empty")]
  public void Should_Throw_When_Creating_Invalid_Category(string description, CategoryPurpose purpose, string expectedMessage)
  {
    var exception = Assert.Throws<DomainException>(() => new Category(description, purpose));
    exception.Message.Should().Contain(expectedMessage);
  }
}