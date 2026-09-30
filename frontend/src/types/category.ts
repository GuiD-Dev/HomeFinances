import type { CategoryPurpose } from "./enums";

export interface Category {
  id?: number,
  description: string,
  purpose: CategoryPurpose,
}