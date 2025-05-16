import type { BaseEntity } from "./base-entity.types";

export type User = BaseEntity & {
    username: string;
    email: string;
    password: string;
    isAdmin: boolean;
}
