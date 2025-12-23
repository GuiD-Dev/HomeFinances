import { useEffect, useState } from 'react'
import type React from 'react'
import type { Category } from '../types/category';

interface Props {
  selectedCategory?: Category | null;
  onSubmit: (person: Omit<Category, "id"> | Category) => void;
  onCancelEdit: () => void;
}

export function CategoryForm({ selectedCategory, onSubmit }: Props) {
  const [description, setDescription] = useState("");
  const [purpose, setPurpose] = useState(0);

  useEffect(() => {
    async function initCategory() {
      if (selectedCategory) {
        setDescription(selectedCategory.description);
        setPurpose(selectedCategory.purpose);
      }
    }

    initCategory();
  }, [selectedCategory])

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();

    onSubmit({ description, purpose });

    setDescription("");
    setPurpose(0);
  }

  return (
    <form onSubmit={handleSubmit}>
      <input
        type='text'
        name='description'
        placeholder='Short Description'
        value={description}
        onChange={e => setDescription(e.target.value)}
        required
      />

      <input
        type='number'
        name='purpose'
        placeholder='Purpose of the Category'
        value={purpose}
        onChange={e => setPurpose(Number(e.target.value))}
        required
      />

      <button type='submit'>
        Save
      </button>
    </form>
  )
}
