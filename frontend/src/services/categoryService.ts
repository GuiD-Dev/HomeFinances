import type { Category } from "../types/category";

const API_URL = "http://localhost:5000";

export async function getCategories(): Promise<Category[]> {
  const response = await fetch(`${API_URL}/category`);
  return response.json();
}

export async function createCategory(category: Category): Promise<void> {
  const response = await fetch(`${API_URL}/category`, {
    method: "POST",
    headers: { 'content-type': 'application/json' },
    body: JSON.stringify(category)
  });

  if (!response.ok) {
    const error = await response.text();
    throw new Error(error || "Error to create category");
  }
}

export async function deleteCategory(id: number) {
  const response = await fetch(`${API_URL}/category/${id}`, {
    method: "DELETE",
    headers: { 'content-type': 'application/json' },
    body: JSON.stringify(id)
  });

  if (!response.ok) {
    const error = await response.text();
    throw new Error(error || "Error to delete category");
  }
}