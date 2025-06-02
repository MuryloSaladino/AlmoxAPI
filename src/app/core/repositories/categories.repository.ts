import { inject, Injectable } from "@angular/core";
import { ApiService } from "../services/api/api.service";
import { Category, CategoryCreation } from "../entities/category.entity";

@Injectable({ providedIn: "root" })
export class CateogoriesRepository {

	private readonly api = inject(ApiService);

	create(categoryCreation: CategoryCreation) {
		return this.api.post<Category>("/categories", categoryCreation);
	}

	getAll() {
		return this.api.get<Category[]>("/categories");
	}

	delete(categoryId: string) {
		return this.api.delete("/categories/" + categoryId);
	}
}
