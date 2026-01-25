import { useEffect, useMemo, useState } from "react";
import { AppHeader } from "../components/AppHeader";
import { getPeopleAndTransactions } from "../services/personService";
import type { Person } from "../types/person";
import styles from "./HomePage.module.css";
import { PeopleTable } from "../components/PeopleTable";

export function HomePage() {
  const [people, setPeople] = useState<Person[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  const { totalRecipes, totalExpenses, totalBalance } = useMemo(() => {
    return people.reduce(
      (totals, person) => {
        totals.totalRecipes += person.recipes;
        totals.totalExpenses += person.expenses;
        totals.totalBalance += person.balance;
        return totals;
      },
      { totalRecipes: 0, totalExpenses: 0, totalBalance: 0 }
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
        <p className={styles.danger}>{error}</p>
      </div>
    );
  }

  return (
    <div>
      <AppHeader pageTitle={"Totals per Person"} />
      <PeopleTable
        people={people}
        totalRecipes={totalRecipes}
        totalExpenses={totalExpenses}
        totalBalance={totalBalance}
      />
    </div>
  );
}