import { BaseEntity } from "./base.entity";
import { Category } from "./category.entity";


export interface Item extends BaseEntity {
	name: string;
	description: string;
	price: number;
	stock: number;
	imageUrl: string | null;
	categories: Category[];
}

export interface ItemCreation {
	name: string;
	description: string;
	price: number;
	stock: number;
    categoryIds: string[];
}
