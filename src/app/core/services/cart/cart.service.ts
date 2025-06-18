import { effect, Injectable, signal } from "@angular/core";
import { StorageKeys } from "../../constants/storage-keys";

@Injectable({ providedIn: "root" })
export class CartService {

	readonly cart = signal<{ [key: string]: number }>({});

	constructor() {
		let storageCart = localStorage.getItem(StorageKeys.CART);

		if(storageCart) {
			this.cart.set(JSON.parse(storageCart))
		}

		effect(() => localStorage.setItem(StorageKeys.CART, JSON.stringify(this.cart())));
	}

	addToCart(itemId: string) {
		const quantity = Number(prompt("How many would you like?", "1"))
		this.cart.update(prev => ({ ...prev, [itemId]: quantity }));
	}

	removeItem(itemId: string) {
		this.cart.update(({ [itemId]: x, ...rest }) => rest);
	}

	clear() {
		this.cart.set({});
	}
}
