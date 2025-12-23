import type { Category } from '../types/category';

interface Props {
  categories: Category[];
  onDelete: (id: number) => void;
}

export function CategoryTable({ categories, onDelete }: Props) {
  return (
    <table border={1} cellPadding={8}>
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
            <td>{category.purpose}</td>
            <td>
              <button onClick={() => onDelete(category.id!)}>Delete</button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  )
}
