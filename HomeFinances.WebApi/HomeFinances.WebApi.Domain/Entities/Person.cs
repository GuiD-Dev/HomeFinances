using HomeFinances.WebApi.Domain.Enums;
using HomeFinances.WebApi.Domain.Exceptions;

namespace HomeFinances.WebApi.Domain.Entities;

public class Person : BaseEntity
{
	public string Name { get; private set; }
	public int Age { get; private set; }

	public virtual ICollection<Transaction> Transactions { get; set; }

	public decimal Incomes => Transactions?.Where(t => t.Type == TransactionType.Income)?.Sum(t => t.Value) ?? 0m;
	public decimal Expenses => Transactions?.Where(t => t.Type == TransactionType.Expense)?.Sum(t => t.Value) ?? 0m;
	public decimal Balance => Incomes - Expenses;

	public Person(string name, int age)
	{
		DomainException.ThrowWhen([
			(string.IsNullOrWhiteSpace(name), "Name cannot be empty"),
			(age <= 0, "Age must be greater than 0"),
		]);

		Name = name;
		Age = age;
		Transactions = new List<Transaction>();
	}

	public void Update(Person data)
	{
		DomainException.ThrowWhen([
			(data.Age < 0, "Age cannot lower than 0"),
			(data.Age < 18 && Incomes > 0, "Person with Incomes cannot have less than 18 years old"),
		]);

		Name = data.Name;
		Age = data.Age;
	}
}
