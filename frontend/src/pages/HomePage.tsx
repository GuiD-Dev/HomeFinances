import { useEffect, useState } from "react";
import { AppHeader } from "../components/AppHeader";
import { getPeopleAndTransactions } from "../services/personService";
import type { Person } from "../types/person";

export function HomePage() {
  const [people, setPeople] = useState<Person[]>([]);
  let [totalRecipes, totalExpenses, totalBelance] = [0, 0, 0];

  useEffect(() => {
    async function fetchPeople() {
      setPeople(await getPeopleAndTransactions());
    }

    fetchPeople();
  }, []);

  return (
    <div>
      <AppHeader pageTitle={"Home"} />

      <table border={1} cellPadding={8}>
        <thead>
          <tr>
            <th>Name</th>
            <th>Age</th>
            <th>Recipes</th>
            <th>Expenses</th>
            <th>Balance</th>
          </tr>
        </thead>
        <tbody>
          {people.map(person => {
            totalRecipes += person.recipes;
            totalExpenses += person.expenses;
            totalBelance += person.balance;

            return (
              <tr key={person.id}>
                <td>{person.name}</td>
                <td>{person.age}</td>
                <td>
                  <span style={{ "color": "green" }}>{person.recipes}</span>
                </td>
                <td>
                  <span style={{ "color": "red" }}>{person.expenses}</span></td>
                <td style={{ "color": "black", "fontWeight": "700", "background": "red" }}>
                  <span>{person.balance}</span>
                </td>
              </tr>
            )
          })}
        </tbody>
        <tfoot>
          <tr>
            <td colSpan={2}>Summary</td>
            <td>{totalRecipes}</td>
            <td>{totalExpenses}</td>
            <td>{totalBelance}</td>
          </tr>
        </tfoot>
      </table>
    </div>
  );
}