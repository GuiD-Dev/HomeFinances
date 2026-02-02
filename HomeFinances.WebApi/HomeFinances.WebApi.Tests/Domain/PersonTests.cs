using FluentAssertions;
using HomeFinances.WebApi.Domain.Entities;
using HomeFinances.WebApi.Domain.Exceptions;

namespace HomeFinances.WebApi.Test.Domain;

public class PersonTests
{
  [Fact]
  public void Should_Create_Valid_Person()
  {
    // Arrange
    var name = "John Doe";
    var age = 30;

    // Act
    var person = new Person(name, age);

    // Assert
    person.Should().NotBeNull();
    person.Name.Should().Be(name);
    person.Age.Should().Be(age);
  }

  [Theory]
  [InlineData("", 30, "Name cannot be empty")]
  [InlineData("John Doe", 0, "Age must be greater than 0")]
  [InlineData("John Doe", -1, "Age must be greater than 0")]
  public void Should_Throw_When_Creating_Invalid_Person(string name, int age, string expectedMessage)
  {
    var exception = Assert.Throws<DomainException>(() => new Person(name, age));
    exception.Message.Should().Contain(expectedMessage);
  }
}