import type { Person } from '../types/person';

interface Props {
  people: Person[];
  onEdit: (person: Person) => void;
  onDelete: (id: number) => void;
}

export function PersonTable({ people, onEdit, onDelete }: Props) {
  return (
    <table border={1} cellPadding={8}>
      <thead>
        <tr>
          <th>Name</th>
          <th>Age</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        {people.map(person => (
          <tr key={person.id}>
            <td>{person.name}</td>
            <td>{person.age}</td>
            <td>
              <button onClick={() => onEdit(person)}>Edit</button>
              <button onClick={() => onDelete(person.id!)}>Delete</button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  )
}
