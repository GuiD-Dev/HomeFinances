import { useEffect, useState } from "react";
import type { Category } from "../types/category";
import { createCategory, deleteCategory, getCategories } from "../services/categoryService";
import { CategoryForm } from "../components/CategoryForm";
import { CategoryTable } from "../components/CategoryTable";
import { AppHeader } from "../components/AppHeader";

export function CategoryPage() {
  const [categories, setCategories] = useState<Category[]>([]);
  const [selectedCategory, setSelectedCategory] = useState<Category | null>(null)

  useEffect(() => {
    async function fetchCategories() {
      setCategories(await getCategories());
    }

    fetchCategories();
  }, []);

  async function handleSubmit(category: Category) {
    await createCategory(category)
    setCategories(await getCategories());
  }

  async function handleDelete(id: number) {
    if (confirm("Confirm the exclusion of the category?")) {
      await deleteCategory(id);
      setCategories(await getCategories());
    }
  }

  return (
    <div>
      <AppHeader pageTitle={"Category Register"} />

      <CategoryForm
        selectedCategory={selectedCategory}
        onSubmit={handleSubmit}
        onCancelEdit={() => setSelectedCategory(null)}
      />

      <CategoryTable
        categories={categories}
        onDelete={handleDelete}
      />
    </div>
  );
}