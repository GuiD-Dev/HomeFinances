import type { Transaction } from "../types/transaction";

const API_URL = "http://localhost:5000";

export async function getTransactions(): Promise<Transaction[]> {
  const response = await fetch(`${API_URL}/transaction`);
  return response.json();
}

export async function createTransaction(Transaction: Transaction): Promise<void> {
  const response = await fetch(`${API_URL}/transaction`, {
    method: "POST",
    headers: { 'content-type': 'application/json' },
    body: JSON.stringify(Transaction)
  });

  if (!response.ok) {
    const error = await response.text();
    throw new Error(error || "Error to create Transaction");
  }
}

export async function deleteTransaction(id: number) {
  const response = await fetch(`${API_URL}/transaction/${id}`, {
    method: "DELETE",
    headers: { 'content-type': 'application/json' },
    body: JSON.stringify(id)
  });

  if (!response.ok) {
    const error = await response.text();
    throw new Error(error || "Error to delete Transaction");
  }
}