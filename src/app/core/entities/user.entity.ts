import { UserRole } from "../types/user-role.types";
import { BaseEntity } from "./base.entity";


export interface User extends BaseEntity {
    username: string;
    email: string;
    role: UserRole;
    departmentId: string;
    departmentName: string;
}

export interface UserCreation extends Omit<User, keyof BaseEntity | "departmentName"> {}
