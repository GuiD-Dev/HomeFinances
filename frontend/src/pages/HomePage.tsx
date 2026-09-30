import { useEffect, useMemo, useState } from "react";
import { AppHeader } from "../components/AppHeader";
import { getPeopleAndTransactions } from "../services/personService";
import type { Person } from "../types/person";
import { Dashboard } from "../components/Dashboard";

export function HomePage() {
  const [people, setPeople] = useState<Person[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  const { totalIncomes, totalExpenses, netBalance } = useMemo(() => {
    return people.reduce(
      (totals, person) => {
        totals.totalIncomes += person.incomes;
        totals.totalExpenses += person.expenses;
        totals.netBalance += person.balance;
        return totals;
      },
      { totalIncomes: 0, totalExpenses: 0, netBalance: 0 }
    );
  }, [people]);

  useEffect(() => {
    async function fetchPeople() {
      try {
        setLoading(true);
        const data = await getPeopleAndTransactions();
        setPeople(data);
        setError(null);
      } catch {
        setError("Failed to fetch data. Please try again later.");
        setPeople([]);
      } finally {
        setLoading(false);
      }
    }

    fetchPeople();
  }, []);

  if (loading) {
    return (
      <div>
        <AppHeader pageTitle={"Totals per Person"} />
        <p>Loading...</p>
      </div>
    );
  }

  if (error) {
    return (
      <div>
        <AppHeader pageTitle={"Totals per Person"} />
        <p style={{ color: 'red' }}>{error}</p>
      </div>
    );
  }

  return (
    <div>
      <AppHeader pageTitle={""} />

      <Dashboard
        people={people}
        totalIncomes={totalIncomes}
        totalExpenses={totalExpenses}
        netBalance={netBalance}
      />
    </div>
  );
}