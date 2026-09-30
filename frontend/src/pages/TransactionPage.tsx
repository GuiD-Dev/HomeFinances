import { useEffect, useState } from "react";
import type { Transaction } from "../types/transaction";
import { createTransaction, deleteTransaction, getTransactions } from "../services/transactionService";
import { AppHeader } from "../components/AppHeader";
import { TransactionForm } from "../components/TransactionForm";
import { TransactionTable } from "../components/TransactionTable";
import type { Category } from "../types/category";
import { getCategories } from "../services/categoryService";
import { getPeople } from "../services/personService";
import type { Person } from "../types/person";

export function TransactionPage() {
  const [categories, setCategories] = useState<Category[]>([]);
  const [people, setPeople] = useState<Person[]>([]);
  const [transactions, setTransactions] = useState<Transaction[]>([]);

  useEffect(() => {
    async function fetchRegistries() {
      setTransactions(await getTransactions());
      setCategories(await getCategories());
      setPeople(await getPeople());
    }

    fetchRegistries();
  }, []);

  async function handleSubmit(transaction: Transaction) {
    try {
      await createTransaction(transaction);
      setTransactions(await getTransactions());
    } catch (error: unknown) {
      if (error instanceof Error)
        alert(error.message);
    }
  }

  async function handleDelete(id: number) {
    if (confirm("Confirm the exclusion of the transaction?")) {
      try {
        await deleteTransaction(id);
        setTransactions(await getTransactions());
      } catch (error) {
        if (error instanceof Error)
          alert(error.message);
      }
    }
  }

  return (
    <div>
      <AppHeader pageTitle={"Transaction Registrer"} />

      <TransactionForm
        categories={categories}
        people={people}
        onSubmit={handleSubmit}
      />

      <TransactionTable
        transactions={transactions}
        onDelete={handleDelete}
      />
    </div>
  );
}