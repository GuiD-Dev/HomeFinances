import type { Person } from "../types/person";

const API_URL = "http://localhost:5000";

export async function getPeople(): Promise<Person[]> {
  const response = await fetch(`${API_URL}/person/list`);
  return response.json();
}

export async function getPeopleAndTransactions(): Promise<Person[]> {
  const response = await fetch(`${API_URL}/person/list-with-transactions`);
  return response.json();
}

export async function createPerson(person: Person): Promise<void> {
  const response = await fetch(`${API_URL}/person`, {
    method: "POST",
    headers: { 'content-type': 'application/json' },
    body: JSON.stringify(person)
  });

  if (!response.ok) {
    const error = await response.text();
    throw new Error(error || "Error to create person");
  }
}

export async function updatePerson(person: Person) {
  const response = await fetch(`${API_URL}/person`, {
    method: "PUT",
    headers: { 'content-type': 'application/json' },
    body: JSON.stringify(person)
  });

  if (!response.ok) {
    const error = await response.text();
    throw new Error(error || "Error to update person");
  }
}

export async function deletePerson(id: number) {
  const response = await fetch(`${API_URL}/person/${id}`, {
    method: "DELETE",
    headers: { 'content-type': 'application/json' },
    body: JSON.stringify(id)
  });

  if (!response.ok) {
    const error = await response.text();
    throw new Error(error || "Error to delete person");
  }
}