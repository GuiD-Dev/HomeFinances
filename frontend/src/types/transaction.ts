import type { TransactionType } from "./enums";

export interface Transaction {
  id?: number,
  description: string,
  value: number,
  type: TransactionType,
  categoryId: number,
  categoryDescription?: string,
  personId: number,
  personName?: string,
}