import { useEffect, useState } from "react";
import type { Category } from "../types/category";
import { createCategory, deleteCategory, getCategories } from "../services/categoryService";
import { CategoryForm } from "../components/CategoryForm";
import { CategoryTable } from "../components/CategoryTable";
import { AppHeader } from "../components/AppHeader";

export function CategoryPage() {
  const [categories, setCategories] = useState<Category[]>([]);

  useEffect(() => {
    async function fetchCategories() {
      setCategories(await getCategories());
    }

    fetchCategories();
  }, []);

  async function handleSubmit(category: Category) {
    try {
      await createCategory(category);
      setCategories(await getCategories());
    } catch (error: unknown) {
      if (error instanceof Error)
        alert(error.message);
    }
  }

  async function handleDelete(id: number) {
    if (confirm("Confirm the exclusion of the category?")) {
      try {
        await deleteCategory(id);
        setCategories(await getCategories());
      } catch (error: unknown) {
        if (error instanceof Error)
          alert(error.message);
      }
    }
  }

  return (
    <div>
      <AppHeader pageTitle={"Category Register"} />

      <CategoryForm onSubmit={handleSubmit} />

      <CategoryTable
        categories={categories}
        onDelete={handleDelete}
      />
    </div>
  );
}