import { Injectable } from "@angular/core";
import { StorageKeys } from "../../constants/storage-keys";

@Injectable({ providedIn: "root" })
export class CartService {

	getCart(): { [key: string]: number } {
		let cart = localStorage.getItem(StorageKeys.CART);

		if(!cart) {
			localStorage.setItem(StorageKeys.CART, "{}");
			return {};
		}

		return JSON.parse(cart);
	}

	addToCart(itemId: string) {
		const quantity = Number(prompt("How many would you like?", "1"))
		const cart = this.getCart();
		cart[itemId] = quantity;
		localStorage.setItem(StorageKeys.CART, JSON.stringify(cart));
	}

	removeItem(itemId: string) {
		const cart = this.getCart();
		delete cart[itemId];
		localStorage.setItem(StorageKeys.CART, JSON.stringify(cart));
	}

	clear() {
		localStorage.setItem(StorageKeys.CART, "{}");
		return {} as { [key: string]: number };
	}
}
