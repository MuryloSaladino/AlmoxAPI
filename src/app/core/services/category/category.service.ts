import { Injectable } from "@angular/core";
import { http } from "../../http";
import { Category, CategoryCreation } from "../../types/entities/category.entity";

@Injectable({ providedIn: "root" })
export class CategoryService {

	async create(categoryCreation: CategoryCreation) {
		return await http.post<Category>("/categories", categoryCreation);
	}

	async getAll() {
		return await http.get<Category[]>("/categories");
	}

	async delete(categoryId: string) {
		return await http.delete("/categories/" + categoryId);
	}
}
