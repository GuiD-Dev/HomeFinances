import { Button, Table } from 'react-bootstrap';
import type { Category } from '../types/category';
import { CategoryPurpose } from '../types/enums';

interface Props {
  categories: Category[];
  onDelete: (id: number) => void;
}

export function CategoryTable({ categories, onDelete }: Props) {
  return (
    <Table striped bordered hover size="md">
      <thead>
        <tr>
          <th>Description</th>
          <th>Purpose</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        {categories.map(category => (
          <tr key={category.id}>
            <td>{category.description}</td>
            <td>{category.purpose === CategoryPurpose.Recipe
              ? "Recipe"
              : category.purpose === CategoryPurpose.Expense
                ? "Expense"
                : "Both"
            }</td>
            <td>
              <Button variant='danger' onClick={() => onDelete(category.id!)}>Delete</Button>
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  )
}
