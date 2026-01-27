import { Table } from "react-bootstrap";
import type { Person } from "../types/person";
import styles from "./Dashboard.module.css";

interface DashboardProps {
  people: Person[];
  totalIncomes: number;
  totalExpenses: number;
  totalBalance: number;
}

export function Dashboard({ people, totalIncomes, totalExpenses, totalBalance }: DashboardProps) {
  return (
    <>
      <Table striped bordered hover size="md">
        <thead>
          <tr>
            <th>Name</th>
            <th>Incomes</th>
            <th>Expenses</th>
            <th>Balance</th>
          </tr>
        </thead>
        <tbody>
          {people.map(person => (
            <tr key={person.id}>
              <td>{person.name}</td>
              <td>
                <span className={styles.success}>{person.incomes}</span>
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
            <td>{totalIncomes}</td>
            <td>{totalExpenses}</td>
            <td>{totalBalance}</td>
          </tr>
        </tfoot>
      </Table>
    </>
  );
}
