import { Injectable } from "@angular/core";
import { http } from "../../http";
import { Category, CategoryCreation } from "../../types/entities/category.entity";
import { Paginated } from "../../http/interfaces";

@Injectable({ providedIn: "root" })
export class CategoryService {

	async create(categoryCreation: CategoryCreation) {
		return await http.post<Category>("/categories", categoryCreation);
	}

	async getAll(search?: string) {
		return await http.get<Paginated<Category>>("/categories" + search);
	}

	async delete(categoryId: string) {
		return await http.delete("/categories/" + categoryId);
	}
}
