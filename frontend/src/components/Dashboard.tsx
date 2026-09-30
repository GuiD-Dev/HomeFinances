import { Card, Table } from "react-bootstrap";
import type { Person } from "../types/person";
import styles from "./Dashboard.module.css";

interface DashboardProps {
  people: Person[];
  totalIncomes: number;
  totalExpenses: number;
  netBalance: number;
}

export function Dashboard({ people, totalIncomes, totalExpenses, netBalance }: DashboardProps) {
  return (
    <>
      <div className={styles.cardsContainer}>
        <Card bg="primary" className={styles.card}>
          <Card.Body>
            <Card.Title style={{ fontWeight: 'bold' }}>Total Incomes</Card.Title>
            <Card.Title style={{ fontWeight: 'bold' }}>R$ {totalIncomes}</Card.Title>
          </Card.Body>
        </Card>

        <Card bg="warning" className={styles.card}>
          <Card.Body>
            <Card.Title style={{ fontWeight: 'bold' }}>Total Expenses</Card.Title>
            <Card.Title style={{ fontWeight: 'bold' }}>R$ {totalExpenses}</Card.Title>
          </Card.Body>
        </Card>

        <Card bg="info" className={styles.card}>
          <Card.Body>
            <Card.Title style={{ fontWeight: 'bold' }}>Net Balance</Card.Title>
            <Card.Title style={{ fontWeight: 'bold' }}>R$ {netBalance}</Card.Title>
          </Card.Body>
        </Card>
      </div>

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
      </Table>
    </>
  );
}
