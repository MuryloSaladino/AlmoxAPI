import { Injectable } from "@angular/core";
import { http } from "../../http";
import { Paginated } from "../../http/interfaces";
import { Item, ItemCreation, ItemUpdate } from "../../types/entities/items.types";

@Injectable({ providedIn: "root" })
export class ItemService {

	async create(itemCreation: ItemCreation) {
		return await http.post<Item>("/items", itemCreation);
	}

	async get(itemId: string) {
		return await http.get("/items/" + itemId);
	}

	async getAll(query: string = "") {
		return await http.get<Paginated<Item>>("/items" + query);
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
