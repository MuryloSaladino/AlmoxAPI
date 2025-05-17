import type { BaseEntity } from "./base-entity.types";

export type User = BaseEntity & {
    username: string;
    email: string;
    isAdmin: boolean;
    departmentId: string;
}

export type UserCreation = Omit<User, keyof BaseEntity> & {
    password: string;
};