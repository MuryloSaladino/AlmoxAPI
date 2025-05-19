import type { BaseEntity } from "./base-entity.types";
import type { CategorySummary } from "./categories.types";

export type Item = BaseEntity & {
    name: string;
    quantity: number;
    categories: CategorySummary[];
}

export type ItemSummary = Omit<Item, "categories">;

export type ItemOrder = {
    id: string;
    name: string;
    quantity: number;
}

export type ItemCreation = { 
    name: string;
};
