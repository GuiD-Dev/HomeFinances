using HomeFinances.WebApi.Domain.Enums;
using HomeFinances.WebApi.Domain.Exceptions;

namespace HomeFinances.WebApi.Domain.Entities;

public class Person : BaseEntity
{
	public string Name { get; private set; }
	public int Age { get; private set; }

	public virtual ICollection<Transaction> Transactions { get; set; }

	public decimal Recipes => Transactions?.Where(t => t.Type == TransactionType.Recipe)?.Sum(t => t.Value) ?? 0m;
	public decimal Expenses => Transactions?.Where(t => t.Type == TransactionType.Expense)?.Sum(t => t.Value) ?? 0m;
	public decimal Balance => Recipes - Expenses;

	public Person(string name, int age)
	{
		DomainException.ThrowsWhen([
			(string.IsNullOrWhiteSpace(name), "Name cannot be empty"),
			(age < 0, "Age cannot lower than 0"),
		]);

		Name = name;
		Age = age;
		Transactions = new List<Transaction>();
	}

	public void Update(Person data)
	{
		DomainException.ThrowsWhen([
			(data.Age < 0, "Age cannot lower than 0"),
			(data.Age < 18 && Recipes > 0, "Person with Recipes cannot have less than 18 years old"),
		]);

		Name = data.Name;
		Age = data.Age;
	}
}
