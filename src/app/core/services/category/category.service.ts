import { Injectable } from "@angular/core";
import { Category, CategoryCreation } from "../../interfaces/entities/category.entity";
import { http } from "../../http";

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
