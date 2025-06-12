import { Component, inject, Input, resource } from "@angular/core";
import { CartService } from "../../../../core/services/cart/cart.service";
import { ItemService } from "../../../../core/services/item/item.service";
import { BrlCurrencyPipe } from "../../../../shared/pipes/brl-currency.pipe";
import { ButtonComponent } from "../../../../shared/components/controls/button/button.component";
import { Item } from "../../../../core/types/entities/items.types";

@Component({
	selector: "cart-item",
	templateUrl: "./cart-item.component.html",
	standalone: true,
	imports: [
		BrlCurrencyPipe,
		ButtonComponent,
	],
})
export class CartItemComponent {

	@Input() item!: Item;
	@Input() quantity!: number;
	@Input() onRemove!: () => void;
}
