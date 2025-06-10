import { Component, Input } from "@angular/core";
import { Order } from "../../../../../core/types/entities/order.entity";
import { TablerIconComponent } from "angular-tabler-icons";
import { FormatDatePipe } from "../../../../../shared/pipes/format-date.pipe";
import { BrlCurrencyPipe } from "../../../../../shared/pipes/brl-currency.pipe";

@Component({
	selector: "order-card",
	templateUrl: "./order-card.component.html",
	standalone: true,
	imports: [
		TablerIconComponent,
		FormatDatePipe,
		BrlCurrencyPipe,
	],
})
export class OrderCardComponent {

	@Input() order!: Order;

	readonly statusColor = {
		"Requested": "bg-blue",
		"Accepted": "bg-yellow",
		"Ready": "bg-green",
		"Completed": "bg-purple",
		"Canceled": "bg-red",
	}

	getTotalCost() {
		return this.order.orderItems.reduce((acc, curr) => (curr.price * curr.quantity) + acc, 0)
	}
}
