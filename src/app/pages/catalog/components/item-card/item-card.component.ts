import { Component, inject, Input } from "@angular/core";
import { CardComponent } from "../../../../shared/components/display/card/card.component";
import { CartService } from "../../../../core/services/cart/cart.service";
import { Item } from "../../../../core/types/entities/items.types";
import { BrlCurrencyPipe } from "../../../../shared/pipes/brl-currency.pipe";
import { AuthService } from "../../../../core/services/auth/auth.service";
import { ButtonComponent } from "../../../../shared/components/controls/button/button.component";

@Component({
	selector: "item-card",
	templateUrl: "./item-card.component.html",
	standalone: true,
	imports: [
    CardComponent,
    BrlCurrencyPipe,
    ButtonComponent
],
})
export class ItemCardComponent {

	@Input() item!: Item;

	readonly cart = inject(CartService);
	readonly auth = inject(AuthService);

	stockColor(quantity: number) {
		if(quantity < 1) return "bg-red";
		if(quantity < 10) return "bg-orange-500";
		if(quantity < 30) return "bg-yellow";
		return "bg-green";
	}
	stockText(quantity: number) {
		if(quantity < 1) return "Out of stock";
		if(quantity < 10) return "Critical Stock";
		if(quantity < 30) return "Low Stock";
		return "In Stock";
	}
}
