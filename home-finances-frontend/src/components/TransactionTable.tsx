import { Button, Table } from 'react-bootstrap';
import type { Transaction } from '../types/transaction';
import { TransactionType } from '../types/enums';

interface Props {
  transactions: Transaction[];
  onDelete: (id: number) => void;
}

export function TransactionTable({ transactions, onDelete }: Props) {
  return (
    <Table striped bordered hover size="md">
      <thead>
        <tr>
          <th>Description</th>
          <th>Value</th>
          <th>Type</th>
          <th>Category</th>
          <th>Person</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        {transactions.map(transaction => (
          <tr key={transaction.id}>
            <td>{transaction.description}</td>
            <td>{transaction.value}</td>
            <td>{transaction.type === TransactionType.Income ? "Income" : "Expense"}</td>
            <td>{transaction.categoryDescription}</td>
            <td>{transaction.personName}</td>
            <td>
              <Button variant='danger' onClick={() => onDelete(transaction.id!)}>Delete</Button>
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  )
}
