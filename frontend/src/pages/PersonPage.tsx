import { useEffect, useState } from "react";
import type { Person } from "../types/person";
import { PersonForm } from "./../components/PersonForm";
import { createPerson, deletePerson, getPeople, updatePerson } from "../services/personService";
import { PersonTable } from "../components/PersonTable";
import { AppHeader } from "../components/AppHeader";

export function PersonPage() {
  const [people, setPeople] = useState<Person[]>([]);
  const [selectedPerson, setSelectedPerson] = useState<Person | null>(null)

  useEffect(() => {
    async function fetchPeople() {
      setPeople(await getPeople());
    }

    fetchPeople();
  }, []);

  async function handleSubmit(person: Person) {
    if (!person.id)
      await createPerson(person)
    else
      await updatePerson(person)

    setPeople(await getPeople());
  }

  async function handleDelete(id: number) {
    if (confirm("Confirm the exclusion of the person?")) {
      await deletePerson(id);
      setPeople(await getPeople());
    }
  }

  return (
    <div>
      <AppHeader pageTitle={"Person Registrer"} />

      <PersonForm
        selectedPerson={selectedPerson}
        onSubmit={handleSubmit}
        onCancelEdit={() => setSelectedPerson(null)}
      />

      <PersonTable
        people={people}
        onEdit={setSelectedPerson}
        onDelete={handleDelete}
      />
    </div>
  );
}