import type { BaseEntity } from "./base-entity.types";

export type Category = BaseEntity & {
    name: string;
    description: string;
}

export type CategorySummary = Omit<Category, 
    | "createdAt"
    | "updatedAt"
    | "deletedAt"
>;

export type CategoryCreation = Omit<Category, keyof BaseEntity>;