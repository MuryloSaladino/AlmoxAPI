import { Component, inject, Input } from "@angular/core";
import { CardComponent } from "../../../../shared/components/display/card/card.component";
import { Order } from "../../../../core/types/entities/order.entity";
import { FormatDatePipe } from "../../../../shared/pipes/format-date.pipe";
import { BrlCurrencyPipe } from "../../../../shared/pipes/brl-currency.pipe";
import { TablerIconComponent } from "angular-tabler-icons";
import { OrderService } from "../../../../core/services/order/order.service";
import { AuthService } from "../../../../core/services/auth/auth.service";

@Component({
	selector: "order-card",
	templateUrl: "./order-card.component.html",
	standalone: true,
	imports: [
		CardComponent,
		FormatDatePipe,
		BrlCurrencyPipe,
		TablerIconComponent,
	],
})
export class OrderCardComponent {

	@Input() order!: Order;
	@Input() refresh!: () => void;

	readonly orderService = inject(OrderService);
	readonly auth = inject(AuthService);

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

	async advanceStatus() {
		const observations = prompt("Observations: ");
		if(observations) {
			await this.orderService.advanceStatus(this.order.id, observations);
			this.refresh();
		}
	}
}
