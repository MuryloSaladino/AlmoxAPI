import { Component, computed, effect, inject, signal } from "@angular/core";
import { CardComponent } from "../../shared/components/card/card.component";
import { CartService } from "../../core/services/cart/cart.service";
import { CartItemComponent } from "./components/cart-item/cart-item.component";
import { OrderSummaryComponent } from "./components/order-summary/order-summary.component";
import { RouterModule } from "@angular/router";
import { AppRoutes } from "../../core/constants/app-routes";
import { ButtonComponent } from "../../shared/components/button/button.component";
import { ItemService } from "../../core/services/item/item.service";
import { Item } from "../../core/types/entities/items.types";

@Component({
	selector: "orders",
	templateUrl: "./cart.component.html",
	standalone: true,
	imports: [
		CardComponent,
		CartItemComponent,
		OrderSummaryComponent,
		RouterModule,
		ButtonComponent
	],
})
export class CartComponent {

	readonly cartService = inject(CartService);
	readonly itemService = inject(ItemService);
	readonly catalog = AppRoutes.CATALOG;

	readonly items = signal<Item[]>([]);

	constructor() {
		effect(async () => this.items.set(await Promise.all(
			Object.keys(this.cartService.cart()).map(async (itemId) => await this.itemService.get(itemId))
		)));
	}

	removeItem(itemId: string) {
		return () => this.cartService.removeItem(itemId);
	}

	getTotal() {
		return this.items().reduce((acc, curr) => (curr.price * this.cartService.cart()[curr.id]) + acc, 0)
	}

	getOrderedItems() {
		return this.items().map(item => ({
			itemId: item.id,
			quantity: this.cartService.cart()[item.id],
		}));
	}

	onOrderCreation() {
		this.cartService.clear();
	}
}
