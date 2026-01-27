import { useState } from 'react'
import type React from 'react'
import type { Category } from '../types/category';
import { Button, Col, Form, Row } from 'react-bootstrap';

interface Props {
  onSubmit: (person: Omit<Category, "id"> | Category) => void;
}

export function CategoryForm({ onSubmit }: Props) {
  const [description, setDescription] = useState("");
  const [purpose, setPurpose] = useState(0);

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();

    onSubmit({ description, purpose });

    setDescription("");
    setPurpose(0);
  }

  return (
    <Form onSubmit={handleSubmit} className='my-4'>
      <Form.Group as={Row}>
        <Form.Label column sm={2}>Description:</Form.Label>
        <Col sm={7}>
          <Form.Control
            type='text'
            name='description'
            placeholder='Short Description'
            value={description}
            onChange={e => setDescription(e.target.value)}
            required
          />
        </Col>

        <Form.Label column sm={1}>Purpose:</Form.Label>
        <Col sm={2}>
          <Form.Select
            defaultValue='0'
            name='purpose'
            value={purpose}
            onChange={e => setPurpose(Number(e.target.value))}
            required
          >
            <option value="0">Income</option>
            <option value="1">Expense</option>
            <option value="2">Both</option>
          </Form.Select>
        </Col>
      </Form.Group>

      <Form.Group as={Row} className="my-2">
        <Button variant="primary" type="submit">
          Save
        </Button>
      </Form.Group>
    </Form>
  )
}
