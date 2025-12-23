import { useEffect, useState } from 'react'
import type React from 'react'
import './PersonForm.css'
import type { Person } from '../types/person';

interface Props {
  selectedPerson?: Person | null;
  onSubmit: (person: Omit<Person, "id"> | Person) => void;
  onCancelEdit: () => void;
}

export function PersonForm({ selectedPerson, onSubmit, onCancelEdit }: Props) {
  const [name, setName] = useState("");
  const [age, setAge] = useState(0);

  useEffect(() => {
    async function initPerson() {
      if (selectedPerson) {
        setName(selectedPerson.name);
        setAge(selectedPerson.age);
      }
    }

    initPerson();
  }, [selectedPerson])

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();

    if (selectedPerson) {
      onSubmit({ id: selectedPerson.id, name, age });
    } else {
      onSubmit({ name, age });
    }

    setName("");
    setAge(0);
  }

  return (
    <form onSubmit={handleSubmit}>
      <h2>Person Register</h2>

      <input
        type='text'
        name='name'
        placeholder='Name of Person'
        value={name}
        onChange={e => setName(e.target.value)}
        required
      />

      <input
        type='number'
        name='age'
        placeholder='Age of Person'
        value={age}
        onChange={e => setAge(Number(e.target.value))}
        required
      />

      <button type='submit'>
        {selectedPerson ? "Update" : "Save"}
      </button>

      {selectedPerson && (
        <button type='button' onClick={onCancelEdit}>
          Cancel
        </button>
      )}
    </form>
  )
}
