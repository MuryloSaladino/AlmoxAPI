import { Injectable } from "@angular/core";
import { StorageKeys } from "../../constants/storage-keys";
import { OrderCreation, OrderItem } from "../../types/entities/order.entity";

@Injectable({ providedIn: "root" })
export class CartService {

	getCart(): OrderCreation["orderedItems"] {
		let cart = localStorage.getItem(StorageKeys.CART);

		if(!cart) {
			localStorage.setItem(StorageKeys.CART, "[]");
			return [];
		}

		return JSON.parse(cart);
	}

	addToCart(itemId: string) {
		const quantity = Number(prompt("How many would you like?")) || 1
		const cart = this.getCart();
		cart.push({ itemId, quantity });
		localStorage.setItem(StorageKeys.CART, JSON.stringify(cart));
	}

	removeItem(itemId: string) {
		const cart = this.getCart().filter(x => x.itemId != itemId);
		localStorage.setItem(StorageKeys.CART, JSON.stringify(cart));
	}
}
