import { Component, inject, Input, signal } from "@angular/core";
import { Delivery } from "../../../../core/types/entities/delivery.entity";
import { FormatDatePipe } from "../../../../shared/pipes/format-date.pipe";
import { DeliveryService } from "../../../../core/services/delivery/delivery.service";
import { TablerIconComponent } from "angular-tabler-icons";
import { BrlCurrencyPipe } from "../../../../shared/pipes/brl-currency.pipe";

@Component({
	selector: "delivery-card",
	templateUrl: "./delivery-card.component.html",
	standalone: true,
	imports: [
		FormatDatePipe,
		BrlCurrencyPipe,
		TablerIconComponent,
	]
})
export class DeliveryCardComponent {

	@Input() delivery!: Delivery;
	@Input() refresh!: () => void;

	readonly deliveryService = inject(DeliveryService);
	readonly statusColors = {
		"Booked": "bg-blue text-blue",
		"InTransit": "bg-purple text-purple",
		"Received": "bg-green text-green",
		"Canceled": "bg-red text-red",
	}

	async advanceStatus() {
		const observations = prompt("Observations: ");
		if(observations) {
			await this.deliveryService.advanceStatus(this.delivery.id, observations);
			this.refresh();
		}
	}

	totalCost() {
		return this.delivery.deliveryItems.reduce((acc, {
			supplierPrice, quantity,
		}) => (supplierPrice * quantity) + acc, 0)
	}
}
