import type { BaseEntity } from "./base-entity.types";

export type User = BaseEntity & {
    username: string;
    email: string;
    isAdmin: boolean;
}
