import { Table } from "react-bootstrap";
import type { Person } from "../types/person";
import styles from "./PeopleTable.module.css";

interface PeopleTableProps {
  people: Person[];
  totalRecipes: number;
  totalExpenses: number;
  totalBalance: number;
}

export function PeopleTable({ people, totalRecipes, totalExpenses, totalBalance }: PeopleTableProps) {
  return (
    <Table striped bordered hover size="md">
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
        {people.map(person => (
          <tr key={person.id}>
            <td>{person.name}</td>
            <td>{person.age}</td>
            <td>
              <span className={styles.success}>{person.recipes}</span>
            </td>
            <td>
              <span className={styles.danger}>{person.expenses}</span>
            </td>
            <td className={person.balance >= 0 ? styles.balanceSuccess : styles.balanceDanger}>
              <span>{person.balance}</span>
            </td>
          </tr>
        ))}
      </tbody>
      <tfoot>
        <tr>
          <td colSpan={2} className={styles.summary}>Summary</td>
          <td>{totalRecipes}</td>
          <td>{totalExpenses}</td>
          <td>{totalBalance}</td>
        </tr>
      </tfoot>
    </Table>
  );
}
