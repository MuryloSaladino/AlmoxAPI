import { Injectable } from "@angular/core";
import { Item, ItemCreation, ItemUpdate } from "../../interfaces/entities/items.types";
import { http } from "../../http";
import { Paginated } from "../../http/interfaces";

@Injectable({ providedIn: "root" })
export class ItemService {

	async create(itemCreation: ItemCreation) {
		return await http.post<Item>("/items", itemCreation);
	}

	async get(itemId: string) {
		return await http.get("/items/" + itemId);
	}

	async getAll() {
		return await http.get<Paginated<Item>>("/items");
	}

	async delete(itemId: string) {
		return await http.delete("/items/" + itemId);
	}

	async update(itemUpdate: ItemUpdate) {
		return await http.put<Item>("/items", itemUpdate);
	}

	// async updateImage(itemId: string, image: Blob) {
	// 	const formData = new FormData();
	// 	formData.append("file", image);
	// 	return http.post<Item>(`/items/${itemId}/image`, formData, {
	// 		"Content-Type": "multipart/form-data"
	// 	});
	// }
}
