namespace HomeFinances.WebApi.Domain.Exceptions;

public class DomainException(string message) : Exception(message)
{
  public static void ThrowsWhen(List<(bool condition, string message)> validations)
  {
    var errors = new List<string>();

    foreach (var validation in validations)
      if (validation.condition) errors.Add(validation.message);

    if (errors.Any())
      throw new DomainException(string.Join(" | ", errors));
  }
}
