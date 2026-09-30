import { Button, Table } from 'react-bootstrap';
import type { Person } from '../types/person';

interface Props {
  people: Person[];
  onEdit: (person: Person) => void;
  onDelete: (id: number) => void;
}

export function PersonTable({ people, onEdit, onDelete }: Props) {
  return (
    <Table striped bordered hover size="md">
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
              <Button variant='primary' onClick={() => onEdit(person)} className='mx-1'>Edit</Button>
              <Button variant='danger' onClick={() => onDelete(person.id!)}>Delete</Button>
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  )
}
