import { Component, computed, inject, resource, signal } from "@angular/core";
import { CreateDeliveryComponent } from "./components/create-delivery/create-delivery.component";
import { DeliveryCardComponent } from "./components/delivery-card/delivery-card.component";
import { CardComponent } from "../../shared/components/display/card/card.component";
import { DeliveryService } from "../../core/services/delivery/delivery.service";
import { TablerIconComponent } from "angular-tabler-icons";

@Component({
	selector: "deliveries",
	templateUrl: "./deliveries.component.html",
	standalone: true,
	imports: [
		CreateDeliveryComponent,
		DeliveryCardComponent,
		CardComponent,
		TablerIconComponent,
	],
})
export class DeliveriesComponent {

	readonly deliveryService = inject(DeliveryService);
	readonly page = signal(1);

	readonly deliveries = resource({
		loader: async () => await this.deliveryService.getAll("?pageSize=3&page=" + this.page()),
		defaultValue: {
			maxPage: 1,
			page: 1,
			pageSize: 3,
			results: []
		}
	})

	readonly refresh = () => this.deliveries.reload();


	async nextPage() {
		this.page.update(prev => Math.min(prev+1, this.deliveries.value()!.maxPage));
		this.deliveries.reload();
	}

	async prevPage() {
		this.page.update(prev => Math.max(prev-1, 1));
		this.deliveries.reload();
	}
}
