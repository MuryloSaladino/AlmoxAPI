import { BaseEntity } from "./base.entity";


export interface Category extends BaseEntity {
    name: string;
}

export interface CategoryCreation extends Omit<Category, keyof BaseEntity> {}
