import { inject, Injectable } from "@angular/core";
import { ApiService } from "../services/api/api.service";
import { Paginated } from "../services/api/api.interfaces";
import { Item, ItemCreation, ItemUpdate } from "../entities/items.types";

@Injectable({ providedIn: "root" })
export class ItemsRepository {

	private readonly api = inject(ApiService);

	create(itemCreation: ItemCreation) {
		return this.api.post<Item>("/items", itemCreation);
	}

	get(itemId: string) {
		return this.api.get("/items/" + itemId);
	}

	getAll() {
		return this.api.get<Paginated<Item>>("/items");
	}

	delete(itemId: string) {
		return this.api.delete("/items/" + itemId);
	}

	update(itemUpdate: ItemUpdate) {
		return this.api.put<Item>("/items", itemUpdate);
	}

	updateImage(itemId: string, image: Blob) {
		const formData = new FormData();
		formData.append("file", image);
		return this.api.post<Item>(`/items/${itemId}/image`, formData, {
			"Content-Type": "multipart/form-data"
		});
	}
}
