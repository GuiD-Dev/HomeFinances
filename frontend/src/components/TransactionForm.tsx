import { useState } from 'react'
import type React from 'react'
import type { Transaction } from '../types/transaction';
import { Button, Col, Form, Row } from 'react-bootstrap';

interface Props {
  onSubmit: (person: Omit<Transaction, "id"> | Transaction) => void;
}

export function TransactionForm({ onSubmit }: Props) {
  const [description, setDescription] = useState("");
  const [value, setValue] = useState(0);
  const [type, setType] = useState(0);
  const [categoryId, setCategoryId] = useState(0);
  const [personId, setPersonId] = useState(0);

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();

    onSubmit({ description, value, type, categoryId, personId });

    setDescription("");
    setValue(0);
    setType(0);
    setCategoryId(0);
    setPersonId(0);
  }

  return (
    <Form onSubmit={handleSubmit} className='my-4'>
      <Form.Group as={Row}>
        <Form.Label column sm={2}>Description:</Form.Label>
        <Col sm={10}>
          <Form.Control
            type='text'
            name='description'
            placeholder='Short Description'
            value={description}
            onChange={e => setDescription(e.target.value)}
            required
          />
        </Col>
      </Form.Group>

      <Form.Group as={Row}>
        <Form.Label column sm={2}>Value:</Form.Label>
        <Col sm={10}>
          <Form.Control
            type='number'
            name='value'
            placeholder='Value'
            value={value}
            onChange={e => setValue(Number(e.target.value))}
            required
          />
        </Col>
      </Form.Group>

      <Form.Group as={Row}>
        <Form.Label column sm={2}>Type:</Form.Label>
        <Col sm={10}>
          <Form.Select
            defaultValue='0'
            name='type'
            value={type}
            onChange={e => setType(Number(e.target.value))}
          >
            <option value="0">Recipe</option>
            <option value="1">Expense</option>
          </Form.Select>
        </Col>
      </Form.Group>

      <Form.Group as={Row}>
        <Form.Label column sm={2}>Category:</Form.Label>
        <Col sm={10}>
          <Form.Control
            type='number'
            name='category'
            placeholder='Category'
            value={categoryId}
            onChange={e => setCategoryId(Number(e.target.value))}
            required
          />
        </Col>
      </Form.Group>

      <Form.Group as={Row}>
        <Form.Label column sm={2}>Person:</Form.Label>
        <Col sm={10}>
          <Form.Control
            type='number'
            name='person'
            placeholder='Person'
            value={personId}
            onChange={e => setPersonId(Number(e.target.value))}
            required
          />
        </Col>
      </Form.Group>

      <Form.Group as={Row} className="mb-3">
        <Button variant="primary" type="submit">
          Save
        </Button>
      </Form.Group>
    </Form>
  )
}
