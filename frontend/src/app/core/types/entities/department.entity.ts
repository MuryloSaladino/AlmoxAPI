import { BaseEntity } from "./base.entity";


export interface Department extends BaseEntity {
    name: string;
    userCount: number;
}

export interface DepartmentCreation extends Omit<Department, keyof BaseEntity | "userCount"> {}
