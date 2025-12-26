import { useEffect, useState } from "react";
import type { Transaction } from "../types/transaction";
import { createTransaction, deleteTransaction, getTransactions } from "../services/transactionService";
import { AppHeader } from "../components/AppHeader";
import { TransactionForm } from "../components/TransactionForm";
import { TransactionTable } from "../components/TransactionTable";

export function TransactionPage() {
  const [transactions, setTransactions] = useState<Transaction[]>([]);

  useEffect(() => {
    async function fetchTransactions() {
      setTransactions(await getTransactions());
    }

    fetchTransactions();
  }, []);

  async function handleSubmit(transaction: Transaction) {
    await createTransaction(transaction)
    setTransactions(await getTransactions());
  }

  async function handleDelete(id: number) {
    if (confirm("Confirm the exclusion of the transaction?")) {
      await deleteTransaction(id);
      setTransactions(await getTransactions());
    }
  }

  return (
    <div>
      <AppHeader pageTitle={"Transaction Registrer"} />

      <TransactionForm onSubmit={handleSubmit} />

      <TransactionTable
        transactions={transactions}
        onDelete={handleDelete}
      />
    </div>
  );
}