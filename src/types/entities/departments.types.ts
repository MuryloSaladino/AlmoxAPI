import type { BaseEntity } from "./base-entity.types";
import type { User } from "./user.types";

export type Department = BaseEntity & {
    name: string;
    users: User[];
}

export type DepartmentSummary = Omit<Department, "users">;

export type DepartmentCreation = Omit<DepartmentSummary, keyof BaseEntity>;
